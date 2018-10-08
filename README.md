# meeting-tracker

This solution attempts to solve the problem of scheduling talks to fit within a given presentation schedule 
ensuring that every talk is allocated the a slot and fits within the day's schedule. 
This is ideally the bin packing problem that requires one to pack objects of different sizes to fit within a specified number of bins.

## About the solution 
The solution consists of four projects:
 1. MeetingTrackManagement.BusinessProcess : contains the logic of scheduling tracks, creating sessions and allocating talks to those sessions
 2. MeetingTrackManagement.WebApp: Asp.Net core web app that users can upload a text file of unscheduled talks and get an output of scheduled talks
 3. MeetingTrackManagement.WebAPI : Angular web client with and asp.net core backend that users upload and view scheduled talks
 4. MeetingTrackManagement.Tests  : test project based on NUnit for testing the business logic of the meeting tracker
 
## Testing The Project
Open the solution using visual studio 2017 and start either of the following projects:
* MeetingTrackManagement.WebApp
* MeetingTrackManagement.WebAPI

A default web page with an upload file action will load on the browser.
Copy the following input test data into a text file and save on your local computer then upload the file to view the scheduled talk output:

- Writing Fast Tests Against Enterprise Rails: 60min
-	Overdoing it in Python: 45min
-	Lua for the Masses: 30min
-	Ruby Errors from Mismatched Gem Versions: 45min
-	Common Ruby Errors: 45min
-	Rails for Python Developers lightning: 35min
-	Communicating Over Distance: 60min
-	Accounting-Driven Development: 45min
-	Woah: 30min
-	Sit Down and Write: 30min
-	Pair Programming vs Noise: 45min
-	Rails Magic: 60min
-	Ruby on Rails: Why We Should Move On?: 60min
-	Clojure Ate Scala (on my project): 45min
-	Programming in the Boondocks of Seattle: 30min
-	Ruby vs. Clojure for Back-End Development: 30min
-	Ruby on Rails Legacy App Maintenance: 60min
-	A World Without HackerNews: 30min
-	User Interface CSS in Rails Apps: 30min
## Execution Time
The assignment took me 1 and half days to fully complete. The breakdown is as follows:
* Coming up with a working prototype took half a day
* Coding the final solution took a whole day to complete.
 
