from flask import Flask, request, jsonify
import json
import numpy as np
import matplotlib.pyplot as plt
import traceback
import cv2
from AiFiles.utils.helper import img_to_encoding , verify, image_to_faces
from PIL import Image
from ultralytics import YOLO

app = Flask(__name__)

##Ai models

@app.route('/examplee', methods=['GET'])
def example_routee(): 
    return "tomato"

@app.route('/imageVerification', methods=['GET'])
def example_route():  # sourcery skip: remove-unreachable-code
    try:
        if request.method == 'GET':
            json_data = request.json
            
            # Parse the JSON string into a Python dictionary
            matrix_dict = json.loads(json_data)
            
            matrix = matrix_dict['image']
            identity=matrix_dict['identity']
            matrix_array = np.array(matrix)
            if matrix_array.dtype == np.int32:
                matrix_array = np.clip(matrix_array, 0, 255).astype(np.uint8)
            reshaped_array = cv2.resize(matrix_array, dsize=(640, 640), interpolation=cv2.INTER_AREA)
            # # Plot the image
            # plt.imshow(reshaped_array)

            # Create PIL image
            image = Image.fromarray(reshaped_array)
            
            faces = image_to_faces(image)
            
            for face in faces:
                
                verified=verify(image,identity)
                
                if(verified):
                    return jsonify({
                                    "name":str(identity),
                                    "true":str(verified)
                                })            
            # results = tflite_model('best.jpeg')
            # Do something with the data
            # For demonstration, let's return a JSON response with the received data
            return jsonify({
                "name":str(identity),
                "true":str(False)
            }) 
            
        else:
            return jsonify({'error': 'Only POST requests are allowed.'}), 405
    except Exception as e:
        with open("logs.txt", "a") as f:
            f.write(str(e) + "\n")
        # Return an error response with a generic message
        return jsonify({"error": "An unexpected error occurred. Please check the server logs."}), 500








if __name__ == '__main__':
    app.run(debug=True)
