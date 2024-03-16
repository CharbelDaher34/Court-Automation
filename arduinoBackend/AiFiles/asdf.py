import os
import cv2
from keras_facenet import FaceNet
import json
os.environ['TF_ENABLE_ONEDNN_OPTS'] = '0'
from PIL import Image
import numpy as np
import tensorflow as tf
embedder = FaceNet()

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
    embedding = embedder.extract(face_array, threshold=0.95)[0]['embedding']
    return embedding / np.linalg.norm(embedding, ord=2)

def process_images(images_folder_path,name):
    """
    Processes all images in a folder and stores their encodings in a JSON file.

    Args:
        images_folder_path: The path to the folder containing images.
    """

    embeddings = []
    for filename in os.listdir(images_folder_path):
        
        # Check if it's a file (not a subfolder) and has an image extension
        if os.path.isfile(os.path.join(images_folder_path, filename)) and filename.lower().endswith(('.jpg', '.jpeg', '.png')):
            # Load the image (replace this with your image loading logic)
            # image = cv2.imread(os.path.join(images_folder_path, filename))

            # Call your image encoding function
            encoding = imgPath_to_encoding(os.path.join(images_folder_path, filename))  # Assuming images aren't pre-encoded
        
            embeddings.append(encoding)
    # Convert NumPy arrays to lists
    embeddings = [embedding.tolist() for embedding in embeddings]
    
    # Create the 'encodings' dictionary
    encodings = {name: embeddings}
    
    # Save the encodings to a JSON file
    with open("encoding.json", 'w') as f:
        json.dump(encodings, f)
    
    print("Encoding saved to encoding.json")


if __name__ == "__main__":
    folder_path = "./images"  # Replace with the actual path to your images folder
    for folder in os.listdir(folder_path):
        folder_path = os.path.join(folder_path, folder)
        if os.path.isdir(folder_path):
            name=str(folder)
            print(f"Processing folder: {folder}")
            # process_images(folder_path,name)
            images_folder_path = folder_path
            embeddings = []
            for filename in os.listdir(images_folder_path):
                
                # Check if it's a file (not a subfolder) and has an image extension
                if os.path.isfile(os.path.join(images_folder_path, filename)) and filename.lower().endswith(('.jpg', '.jpeg', '.png')):
                    # Load the image (replace this with your image loading logic)
                    # image = cv2.imread(os.path.join(images_folder_path, filename))
        
                    # Call your image encoding function
                    # encoding = imgPath_to_encoding(os.path.join(images_folder_path, filename))  # Assuming images aren't pre-encoded
                     
                     
                    image = Image.open(os.path.join(images_folder_path, filename))

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
                    embedding = embedder.extract(face_array, threshold=0.95)[0]['embedding']
                    encoding= embedding / np.linalg.norm(embedding, ord=2)
                            
                    embeddings.append(encoding)
            # Convert NumPy arrays to lists
            embeddings = [embedding.tolist() for embedding in embeddings]
            
            # Create the 'encodings' dictionary
            encodings = {name: embeddings}
            
            # Save the encodings to a JSON file
            with open("encoding.json", 'w') as f:
                json.dump(encodings, f)
            
            print("Encoding saved to encoding.json")
            
            
            
            
            print("\n\n\n\n\n\n next \n\n\n\n\n\n\n")

