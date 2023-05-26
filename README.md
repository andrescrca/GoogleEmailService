# GoogleEmailService
Google Email Service Application
This is a simple console application that demonstrates how to use the GoogleEmailService class to send emails using the Gmail API.

Prerequisites
Before running the application, make sure you have completed the following steps:

Download the credentials file from the Google Developers Console. Save it as Credentials-email.json in the Providers directory of the application.
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

License
This application is released under the MIT License.
