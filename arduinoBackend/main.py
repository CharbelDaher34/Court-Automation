from flask import Flask, request, jsonify
import json
import numpy as np
import cv2
from AiFiles.utils.helper import img_to_encoding , verify, image_to_faces, add_encoding_to_json
from PIL import Image
from flask import make_response
import io

from flask_cors import CORS

app = Flask(__name__)
CORS(app)


##Ai models
@app.route('/imageVerification', methods=['GET'])
def identityVerification():  
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
                try:
                    verified=verify(face,identity)
                except:
                    continue
                
                
                
                # if(verified):
                #     data = {'name': str(identity), 'true': str(verified)}
                #     response = make_response(json.dumps(data), 200)
                #     response.headers['Content-Type'] = 'application/json'
                #     return response
                
               
                if(verified):
                    return jsonify({
                                    "name":str(identity),
                                    "verified":str(verified)
                                })            
            # data = {'name': str(identity), 'verified': verified }
            # response = make_response(json.dumps(data), 401)  # Or appropriate status code
            # response.headers['Content-Type'] = 'application/json'
            # return response
                  
            return jsonify({
                "name":str(identity),
                "verified":str(False)
            }) 
            
        else:
            return jsonify({'error': 'Only POST requests are allowed.'}), 405
    except Exception as e:
        # Return an error response with a generic message
        return jsonify({"error": "An unexpected error occurred. Please check the server logs."}), 500



@app.route('/embeddingCreation', methods=['POST'])
def embeddingCreation():
    if request.content_type.startswith('multipart/form-data'):
        if 'image' in request.files:
            # Get the uploaded image file
            image_file = request.files['image']
            
            # Read the image file using PIL (Pillow)
            image = Image.open(io.BytesIO(image_file.read()))
                        
        # Convert the image to a NumPy array
            image_array = np.array(image)
        
        # Check and clip the dtype if it's np.int32
            if image_array.dtype == np.int32:
                image_array = np.clip(image_array, 0, 255).astype(np.uint8)
            
            # Resize the array
            resized_array = cv2.resize(image_array, dsize=(640, 640), interpolation=cv2.INTER_AREA)
            
            # Convert the resized array back to an image
            image = Image.fromarray(resized_array)          
            identity = request.form['identity']
    else:
        json_data = request.json
        matrix_dict = json.loads(json_data)
    
        matrix = matrix_dict['image']
        identity=matrix_dict['identity']
        matrix_array = np.array(matrix)
        if matrix_array.dtype == np.int32:
            matrix_array = np.clip(matrix_array, 0, 255).astype(np.uint8)
        reshaped_array = cv2.resize(matrix_array, dsize=(640, 640), interpolation=cv2.INTER_AREA)
        image = Image.fromarray(reshaped_array)


    
    faces = image_to_faces(image)
    if (len(faces) == 0 ):
        return '0'
        return jsonify({
                    "status":"No face found in the image",
                    "code":0 #no faces found
                }) 
        
    if (len(faces) > 1 ):
        return '2'
        return jsonify({
                    "status":"The photo must only feature your face",
                    "code":2 #more than 1 face found, needed one
                }) 
    
    
    encoding=img_to_encoding(image)
    add_encoding_to_json(encoding,identity)
    return '1'
    return jsonify({
                    "status":"encoding of your face added to the database",
                    "code":1 #face added
        }) 
    





if __name__ == '__main__':
    app.run(debug=True)
