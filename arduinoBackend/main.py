from flask import Flask, request, jsonify
import json
import numpy as np
import matplotlib.pyplot as plt
import traceback
import cv2
from keras_facenet import FaceNet
from AiFiles.utils.helper import img_to_encoding

app = Flask(__name__)

@app.route('/examplee', methods=['GET'])
def example_routee(): 
    return "tomato"

@app.route('/example', methods=['GET'])
def example_route():  # sourcery skip: remove-unreachable-code
    try:
        if request.method == 'GET':
            json_data = request.json
            
            # Parse the JSON string into a Python dictionary
            matrix_dict = json.loads(json_data)
            
            matrix = matrix_dict['image']
            identity=matrix_dict['identity']
            # Convert the matrix to a NumPy array
            matrix_array = np.array(matrix)
        # Assuming `matrix_array` is of type int32
            if matrix_array.dtype == np.int32:
               # Clip and scale values to the 0-255 range for uint8
               matrix_array = np.clip(matrix_array, 0, 255).astype(np.uint8)
            # Reshape the array to the desired shape
            reshaped_array = cv2.resize(matrix_array, dsize=(640, 640), interpolation=cv2.INTER_AREA)
            # Plot the image
            plt.imshow(reshaped_array)
            embedder = FaceNet()
            encoding=img_to_encoding

    
            # Do something with the data
            # For demonstration, let's return a JSON response with the received data
            return jsonify({
                "imageArray":reshaped_array,
                "true":identity
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
