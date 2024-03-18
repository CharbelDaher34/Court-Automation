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
for root, dirs, files in os.walk(".."):
    if 'best_float32.tflite' in files:
        model_path = os.path.join(root, 'best_float32.tflite')
        tflite_model =YOLO(model_path,task='detect')

 


# tflite_model =YOLO("AiFiles/faceDetectionModel/best_float32.tflite",task='detect')

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
        embedding = embedder.extract(face_array, threshold=0.80)[0]['embedding']
    except Exception as e:
        # Code to handle any error
        print(f"An error occurred: {e}")
        print("\nErrow with the following image:",image)
    return embedding / np.linalg.norm(embedding, ord=2)

def verify(img, identity):
    encoding = img_to_encoding(img)
    start_dir = '.' 
    data = find_encoding_json(start_dir)
    for enc in data[identity]:
        dist = np.linalg.norm(encoding-enc)
        if dist<0.7:
            print(f"It\'s {identity}, welcome in ")
            door_open = True
        else:
            print(f"It\'s not {identity} , go away")
            door_open = False
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


def add_encoding_to_json(encoding,identity):
    start_dir='.'
    for root, dirs, files in os.walk(start_dir):
        if 'encoding.json' in files:
            encoding_json_path = os.path.join(root, 'encoding.json')
            
            with open(encoding_json_path, 'r') as f:
                data =json.load(f)
            
            if identity in data.keys():
                # Ensure 'identity' is a list (create an empty list if it doesn't exist)
                data['identity'] = data.get('identity', [])
                data['identity'].append(encoding.tolist())
            else:
                data['identity'] = [encoding.tolist()]
            
            # Write the updated data back to the JSON file
            with open(encoding_json_path, 'w') as f:
                json.dump(data, f)


            return data
    return None 


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



