import json
import requests
import numpy as np
from PIL import Image

from PIL import Image
import matplotlib.pyplot as plt

def display_image_with_title(image_path, title):
  """
  Displays a Pillow image with a title using Matplotlib.

  Args:
      image_path: Path to the image file.
      title: The title to be displayed.
  """

  # Open the image with Pillow
  img = Image.open(image_path)

  # Convert image to RGB format (required for Matplotlib)
  img_rgb = img.convert("RGB")

  # Create a figure for plotting
  fig, ax = plt.subplots()

  # Display the image
  ax.imshow(img_rgb)
  ax.axis("off")  # Hide axes for cleaner presentation

  # Add title as text annotation
  plt.title(title, fontsize=16, ha="center")  # Center-aligned title

  # Display the plot
  plt.show()



# Load the image
image_paths = ["./AiFiles/testingPhotos/a.jpeg","./AiFiles/testingPhotos/b.jpeg","./AiFiles/testingPhotos/c.jpeg"]

for image_path in image_paths:
    # Replace with the path to your image
    image = Image.open(image_path)
    
    # Convert the image to a 3D array (RGB format)
    image_array = np.array(image)
    
    # Convert the array to a list (to be JSON serializable)
    image_list = image_array.tolist()
    
    # Prepare JSON payload
    payload = {
               'image': image_list, 
               'identity':"daher"
            }
    json_payload = json.dumps(payload)
    
    # Send HTTP POST request
    url = "http://127.0.0.1:5000/imageVerification"  # Replace with your API endpoint
    response = requests.get(url, json=json_payload)
    
    if response.status_code == 200:
        display_image_with_title(image_path,response.text )

        
        print(response.text)
    else:
        print("Error:", response.status_code)









