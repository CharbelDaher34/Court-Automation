import os
from utils.helper import imgPath_to_encoding
import cv2
from keras_facenet import FaceNet
import json
os.environ['TF_ENABLE_ONEDNN_OPTS'] = '0'


def process_images(images_folder_path,model,name):
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
            encoding = imgPath_to_encoding(os.path.join(images_folder_path, filename), model)  # Assuming images aren't pre-encoded
        
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
    embedder = FaceNet()
    folder_path = "./images"  # Replace with the actual path to your images folder
    for folder in os.listdir(folder_path):
        folder_path = os.path.join(folder_path, folder)
        if os.path.isdir(folder_path):
            name=str(folder)
            print(f"Processing folder: {folder}")
            process_images(folder_path,embedder,name)
            print("\n\n\n\n\n\n next \n\n\n\n\n\n\n")

