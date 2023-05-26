#Google Email Service Application
This is a simple console application that demonstrates how to use the GoogleEmailService class to send emails using the Gmail API.

Prerequisites
Before running the application, make sure you have completed the following steps:

Create a Google Cloud Platform (GCP) project and enable the Gmail API for the project.
Create a service account within your GCP project and generate a credentials file in JSON format.
Save the credentials file as Credentials-email.json in the Providers directory of the application.
Configure the appropriate access and permissions for the service account to send emails on behalf of your desired sender address.
Replace the placeholder email addresses in the senderEmail and recipientEmail variables with the appropriate email addresses.
Installation
Clone the repository or download the source code files.
Open the project in your preferred IDE or text editor.
Usage
Open the Program.cs file in the GoogleEmailService.APP namespace.
Locate the Main method, which serves as the entry point of the application.
Ensure that the credentialsFilePath variable is correctly set to the path of your Credentials-email.json file.
Update the senderEmail and recipientEmail variables with the desired email addresses for the sender and recipient.
Customize the subject and body variables to define the email's subject and content.
Run the application.
If everything is set up correctly, the application will send an email using the provided credentials and display a success message. If an error occurs during the email sending process, an error message will be displayed instead.

Cleaning Up
After running the application, it is recommended to dispose of the resources used by the GoogleEmailService instance. This is done automatically in the provided code by calling the Dispose method on the emailService object in the finally block.

Important Note
To successfully use the Gmail API, it is crucial to have a well-configured service account within your Google Cloud Platform project. The service account should have the necessary permissions and access to send emails on behalf of the specified sender address. Make sure to follow the Google Cloud Platform documentation and guidelines to properly set up your service account and configure the required access and permissions.

License
This application is released under the MIT License.
