## Auto-Court Project

### Introduction

Efficient management and smooth operations are crucial in sports courts and similar establishments. Traditional methods like phone reservations and handwritten notes often lead to inefficiencies and mismanagement. Our project aims to revolutionize court management by automating reservations and administrative tasks, enhancing operational efficiency, and providing a seamless user experience.

### Project Components

1. **Website for Court Reservation**:
   - A user-friendly Django website ([userWebsite folder](./userWebsite)) for browsing and reserving courts, with real-time availability.

2. **Windows Form Application for Admin Management**:
   - A C# application for administrators to manage client information, court details, and reservation schedules.

3. **Arduino-Based Court Management System**:
   - An automated system for court access and lighting using IoT technology.

### Features and Technologies

- **Web Application**: Built using Python and Django for online reservations and user interactions.
- **Admin Application**: Developed in C# for managing clients, courts, schedules, customer reviews, and inventory.
- **Database**: MySQL for managing client, court, and reservation data.
- **Computer Vision**: Face detection and verification using YOLOv8 and Facenet, with an API for creating embeddings and verifying faces.
- **Electronics Technology**: Integration of Arduino boards, sensors, and actuators for automating court management.

### My Contributions

- Developed the **website using Django** (located in the [userWebsite folder](./userWebsite)).
- Implemented the **computer vision** system using Facenet and YOLO.
- Created the **API for accessing the computer vision models**, located in the [arduinoBackend folder](./arduinoBackend).
- Designed the **database** for managing client, court, and reservation data.


### Conclusion

The Auto-Court project automates sports court management, improving efficiency and user experience through advanced technologies like web applications and computer vision. This project streamlines administrative tasks and offers a secure, user-friendly platform for court reservations and management.
