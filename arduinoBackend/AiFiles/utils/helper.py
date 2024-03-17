#tf.keras.backend.set_image_data_format('channels_last')
from PIL import Image
from numpy import asarray
import numpy as np
import cv2
import json
import os
from ultralytics import YOLO
from keras_facenet import FaceNet

embedder=FaceNet()
tflite_model =YOLO("AiFiles/faceDetectionModel/best_float32.tflite",task='detect')

def imgPath_to_encoding(image_path):
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


def img_to_encoding(image):
    # Check if the image has four layers (RGBA)
    if image.mode == "RGBA":
        # Convert the image to RGBA mode if it's not already
        image = image.convert("RGBA")
        # Split the image into individual channels
        r, g, b, a = image.split()
        # Merge the RGB channels (discard the alpha channel)
        image = Image.merge("RGB", (r, g, b))
    face_array=np.asarray(image)
    
    if face_array.dtype == np.int32:
        face_array = np.clip(face_array, 0, 255).astype(np.uint8) 
    face_array = cv2.resize(face_array, dsize=(640, 640), interpolation=cv2.INTER_AREA)
    try:
        embedding = embedder.extract(face_array, threshold=0.95)[0]['embedding']
    except Exception as e:
        # Code to handle any error
        print(f"An error occurred: {e}")
        print("\nErrow with the following image:",image)
    return embedding / np.linalg.norm(embedding, ord=2)

def verify(img, identity):
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
    
    encoding = img_to_encoding(img)
    # Example usage:
    start_dir = '.'  # Start searching from the current directory
    data = find_encoding_json(start_dir)
    for enc in data[identity]:
        
    # Step 2: Compute distance with identity's image (≈ 1 line)
    # with open("encoding.json", "r") as f:
    #     data = json.load(f)
        dist = np.linalg.norm(encoding-enc)
        # Step 3: Open the door if dist < 0.7, else don't open (≈ 3 lines)
        if dist<0.7:
            print(f"It\'s {identity}, welcome in ")
            door_open = True
        else:
            print(f"It\'s not {identity} , go away")
            door_open = False
        ### END CODE HERE        
        return door_open
    return False



def find_encoding_json(start_dir):
    for root, dirs, files in os.walk(start_dir):
        if 'encoding.json' in files:
            encoding_json_path = os.path.join(root, 'encoding.json')
            with open(encoding_json_path, 'r') as f:
                data = json.load(f)
            return data
    return None  # If encoding.json is not found in any directory




def image_to_faces(img):
    results = tflite_model(img)
    # Assuming you have the image as a NumPy array and a list of results as described
    cropped_images = []
    for result in results:
        boxes = result.boxes.cpu().numpy()  # Get bounding boxes as NumPy array
        for box in boxes:
            x1, y1, x2, y2 = box.xyxy[0]  # Extract coordinates as integers
            cropped_box = (x1, y1, x2, y2)
            # Crop the image
            cropped_img = img.crop(cropped_box) # Crop the image using the bounding box coordinates
        
            cropped_images.append(cropped_img)
    return cropped_images



