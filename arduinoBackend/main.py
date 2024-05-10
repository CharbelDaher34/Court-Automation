from flask import Flask, request, jsonify
import json
import numpy as np
import cv2
from AiFiles.utils.helper import img_to_encoding , verify, image_to_faces, add_encoding_to_json
from PIL import Image
from flask import make_response

app = Flask(__name__)

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
        with open("logs.txt", "a") as f:
            f.write(str(e) + "\n")
        # Return an error response with a generic message
        return jsonify({"error": "An unexpected error occurred. Please check the server logs."}), 500



@app.route('/embeddingCreation', methods=['POST'])
def embeddingCreation():
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
    if (len(faces) == 0 )):
        return jsonify({
                    "status":str("No face found in the image"),
                }) 
    
    
    encoding=img_to_encoding(image)
    add_encoding_to_json(encoding,identity)
    return True 





if __name__ == '__main__':
    app.run(debug=True)
