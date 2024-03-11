#tf.keras.backend.set_image_data_format('channels_last')
from PIL import Image
from numpy import asarray
import numpy as np
import cv2
import json
import os
def imgPath_to_encoding(image_path, embedder):
    image = Image.open(image_path)

    # Check if the image has four layers (RGBA)
    if image.mode == "RGBA":
        # Convert the image to RGBA mode if it's not already
        image = image.convert("RGBA")
        
        # Split the image into individual channels
        r, g, b, a = image.split()

        # Merge the RGB channels (discard the alpha channel)
        image = Image.merge("RGB", (r, g, b))
        
    matrix_array=np.asarray(image)        
    if matrix_array.dtype == np.int32:
        matrix_array = np.clip(matrix_array, 0, 255).astype(np.uint8)
            # Reshape the array to the desired shape
        face_array = cv2.resize(matrix_array, dsize=(640, 640), interpolation=cv2.INTER_AREA)        
    
    face_array=np.asarray(image)
    
    try:
        embedding = embedder.extract(face_array, threshold=0.95)[0]['embedding']
    except Exception as e:
        # Code to handle any error
        print(f"An error occurred: {e}")
        print("\nErrow with the following image:",image_path)
        
        print("\nErrow with the following image:",image)


    
    return embedding / np.linalg.norm(embedding, ord=2)


def img_to_encoding(image, embedder):
    # Check if the image has four layers (RGBA)
    if image.mode == "RGBA":
        # Convert the image to RGBA mode if it's not already
        image = image.convert("RGBA")
        
        # Split the image into individual channels
        r, g, b, a = image.split()

        # Merge the RGB channels (discard the alpha channel)
        image = Image.merge("RGB", (r, g, b))
        
    face_array=np.asarray(image)
    
    try:
        embedding = embedder.extract(face_array, threshold=0.95)[0]['embedding']
    except Exception as e:
        # Code to handle any error
        print(f"An error occurred: {e}")
        print("\nErrow with the following image:",image_path)
        
        print("\nErrow with the following image:",image)


    
    return embedding / np.linalg.norm(embedding, ord=2)

def verify(img, identity, model):
    """
    Function that verifies if the person on the "image_path" image is "identity".
    
    Arguments:
        image_path -- path to an image
        identity -- string, name of the person you'd like to verify the identity. Has to be an employee who works in the office.
        database -- python dictionary mapping names of allowed people's names (strings) to their encodings (vectors).
        model -- your Inception model instance in Keras
    
    Returns:
        dist -- distance between the image_path and the image of "identity" in the database.
        door_open -- True, if the door should open. False otherwise.
    """
    ### START CODE HERE
    # Step 1: Compute the encoding for the image. Use img_to_encoding() see example above. (≈ 1 line)
    encoding = img_to_encoding(img,model)

    # Example usage:
    start_dir = '.'  # Start searching from the current directory
    data = find_encoding_json(start_dir)
    # Step 2: Compute distance with identity's image (≈ 1 line)
    # with open("encoding.json", "r") as f:
    #     data = json.load(f)
    dist = np.linalg.norm(encoding-data[identity])
    # Step 3: Open the door if dist < 0.7, else don't open (≈ 3 lines)
    if dist<0.7:
        print("It's " + str(identity) + ", welcome in!")
        door_open = True
    else:
        print("It's not " + str(identity) + ", please go away")
        door_open = False
    ### END CODE HERE        
    return dist, door_open



def find_encoding_json(start_dir):
    for root, dirs, files in os.walk(start_dir):
        if 'encoding.json' in files:
            encoding_json_path = os.path.join(root, 'encoding.json')
            with open(encoding_json_path, 'r') as f:
                data = json.load(f)
            return data
    return None  # If encoding.json is not found in any directory

