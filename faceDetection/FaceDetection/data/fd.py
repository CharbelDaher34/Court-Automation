import os
import shutil

# Function to move all files to root folder
def move_files_to_root(root_folder):
    # Walk through all directories and files
    for dirpath, _, filenames in os.walk(root_folder):
        for filename in filenames:
            # Construct full path of the file
            file_path = os.path.join(dirpath, filename)
            # Move file to root folder
            shutil.move(file_path, os.path.join(root_folder, filename))

# Root folder where all files are located
root_folder = './'

# Move all files to root folder
move_files_to_root(root_folder)
