# miniRabbitMessageSender
###shot :
<img width="1800" height="632" alt="image" src="https://github.com/user-attachments/assets/9b7720c7-287e-40bf-a115-ec6a12080f0e" />



`miniRabbitMessageSender` is a simple message queue application using **RabbitMQ** to handle the sending and receiving of SMS-like notifications. This project demonstrates how to set up a basic **Publisher-Subscriber** pattern with **RabbitMQ** using **C#**.

## Project Structure

1. **Publisher**: The `Publisher` application sends phone numbers (or any string) to a RabbitMQ queue called `register_user`.
2. **SMS Processor**: The `SMS Processor` listens to the `register_user` queue and simulates sending SMS notifications to the phone numbers it receives.

## Technologies Used

- **RabbitMQ**: A message broker used for message queuing.
- **C#**: The primary language for building both the publisher and subscriber.
- **.NET 5/6/7**: Framework used for the C# application.
  
## Features

- **Publisher**:
  - Reads phone numbers from the user.
  - Sends phone numbers to the RabbitMQ queue (`register_user`).
  
- **SMS Processor**:
  - Consumes messages from the `register_user` queue.
  - Simulates processing by displaying the phone number and acknowledging the message.

## Requirements

- **RabbitMQ** server running on your machine or a cloud instance.
  - Default port: 5672
  - Default credentials: `guest/guest`
  
- **.NET SDK** (5.0 or higher)
  
- **Visual Studio** or another C# compatible IDE.

## Setup

### Step 1: Install RabbitMQ

1. Download and install RabbitMQ from the official website: [RabbitMQ Installation](https://www.rabbitmq.com/download.html)
2. Run RabbitMQ Server on your machine.
   - By default, RabbitMQ runs on `localhost:5672`.

### Step 2: Clone the Repository

Clone the repository to your local machine using Git:

```bash
git clone https://github.com/devbybahman/miniRabbitMessageSender.git
