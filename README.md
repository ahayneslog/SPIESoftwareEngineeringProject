# SPIESoftwareEngineeringProject

This is my submission to the take home assignment for the SPIE Software Engineering position. 

# How to Start up Service
- Download zip and put it into a new solution in Visual Studio
- Build the project
	- If you run into issues building the project, it may be Roslyn related. To resolve this issue, go to "Package Manager Console" 
	and type in the following command: `Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r`
- To start the project, you may need to switch the "View" of the project if you run into issues with the Debugger not stating "IIS Express (browser of your choice)". 
You can switch the view of the project by going to "Solution Explorer" and look for the icon that has a folder and a console window. Click it and select "WebApplication.sln"

## Bug Fixes
- On the home page, the search profiles text box doesn't line up with the magnifying glass. Change it so the bottom of the text box lines up with the magnifying glassimage
	- **A fix has been implemented.**
- When clicking on a SPIE Profile Name link, it's supposed to send you to the profile information for that particular person. It is currently always displaying Jim Bob's profile. Fix it so it displays the correct profile when you click on it.
	- **A fix has been implemented.**
- An individual profile can be accessed by using the following URL format: /profiles/view/{ID} There are two errors that come up:
	- If you enter a non-number as the ID, it errors out (e.g. /profiles/view/asdf). Change it to simply redirect to the home page if a profile is not found
		- **A fix has been implemented.**
	- Depending on how you fix the SPIE Profile Name Link error, if you enter a non-existant profile ID, it may error out (e.g. /profiles/view/123). Make sure it does not. 
		- **A fix has been implemented.**

## Added Functionality
- Add the ability to use the search bar, and have it display a list of profiles that have a partial match with either first or last name
	- **This feature has been implemented.**
- Add the ability for someone to edit a profile and have it update
	- Also can move this ability to edit behind a log in, so random users can't maliciously edit someone else's profile!
		
- Add the ability for a profile user to log into the website
	- **This feature has been implemented.**

## New Features not part of the Requirements/Unmentioned Bugs
- Randomization of profiles in the "Who's using SPIE?'" feature on the right side of the page. 
- The Sign Up link did not work. I have created a page that allows a user to create a basic profile. 
- I added more profiles manually that covers more interesting name search scenarios.