import json
import requests
import numpy as np
from PIL import Image

# Load the image
image_path = "./AiFiles/images/andrew/andrew.jpg"  # Replace with the path to your image
image = Image.open(image_path)

# Convert the image to a 3D array (RGB format)
image_array = np.array(image)

# Convert the array to a list (to be JSON serializable)
image_list = image_array.tolist()

# Prepare JSON payload
payload = {
           'image': image_list, 
           'identity':"andrew"
        }
json_payload = json.dumps(payload)

# Send HTTP POST request
url = "http://127.0.0.1:5000/imageVerification"  # Replace with your API endpoint
response = requests.get(url, json=json_payload)

# Check response status
if response.status_code == 200:
    print(response.text)
else:
    print("Error:", response.status_code)
