import os
import cv2
from PIL import Image
import json
from utils.helper import img_to_encoding
photosWithNames={}
folder_path = "./images"  # Replace with the actual path to your images folder
for folder in os.listdir(folder_path):
    imgfolder_path = os.path.join(folder_path, folder)
    photosWithNames[folder]=[]
    for filename in os.listdir(imgfolder_path):
        # Check if it's a file (not a subfolder) and has an image extension
        if os.path.isfile(os.path.join(imgfolder_path, filename)) and filename.lower().endswith(('.jpg', '.jpeg', '.png')):
            image = Image.open(os.path.join(imgfolder_path, filename))
            photosWithNames[folder].append(image)
            
            
def process_image_lists(image_dict, img_to_encoding):
  """
  Iterates through a dictionary of Pillow image lists, applies a function
  to each image, and saves the output in place of the image.

  Args:
      image_dict: A dictionary where keys are strings and values are lists of Pillow Images.
      img_to_encoding: A function that takes a Pillow Image and returns its encoding.
  """

  for key, image_list in image_dict.items():
    # Create a temporary list to store encodings
    encoded_images = []

    for image in image_list:
      # Apply function to image and get encoding
      encoding = img_to_encoding(image)
      # Append encoding to temporary list
      encoded_images.append(encoding.tolist())

    # Replace the original image list with the encoded list in the dictionary
    image_dict[key] = encoded_images

# Example usage (assuming you have image_dict and img_to_encoding function)
process_image_lists(photosWithNames, img_to_encoding)


for root, dirs, files in os.walk("."):
    if 'encoding.json' in files:
        print("sd")
        encoding_json_path = os.path.join(root, 'encoding.json')
        with open(encoding_json_path, 'w') as f:
          json.dump(photosWithNames,f)





