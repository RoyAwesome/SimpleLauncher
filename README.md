# SimpleLauncher
A simple C# game launcher.  Designed for use in Unreal Engine 4, but can be used for just about anything.

# Setup

### Intial Setup
* Set up a webserver of some kind.  Create a folder named `game` on the webserver
* Create a file named `changelog.html`.  Fill it with your changelog infomation.
* Create a file named `manifest.txt`.  Leave it blank for now
* Clone project
* In visual studio, double click Settings.  Change the changelog.html location to your changelog.  Same for Manifest.
* Run the Launcher.  
* Click the Options tab.  Change the following in the launcher options:
  * `Builder_LastBuildNumber` to 1 (this will autoincrement)
  * `Builder_LastExecutable` to your game's executable file (path relative to the game directory)
  * `Builder_LastURL` to the url of the `game` folder on your webserver.
  
### Building a Game Version

* Press `Build Manifest`.  Navigate to your game's build folder.  
* Save the generated Manifest.txt. 
* Replace the Manifest.txt on your webserver with the generated file.
* Upload all of your game files into the `game` directory on your web server.



