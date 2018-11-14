# Intro to Git
~This guide is addapted from Roger Dudler's Git Guide: http://rogerdudler.github.io/git-guide/~

Git allows each of us to work on the same project without interfering with each other's work, and later combine our pieces together. 

### The Pipeline
Our project exists on the main branch: ~master~
The master branch consists of the base of our project and is properly functioning. 
When developing and testing our own pieces, we do so 

it's important that we don't touch the master branch until our piece is completed and working. 
![large](./docs/assets/branches.png)

# Getting Started
### Cloning the Project
![medium](./docs/assets/git_clone.png)

# How to add & commit files
~git add <filename>~ or ~git add .~ to add all in the directory
~git status~ to review what files have been added
~git commit -m "Commit message"~ to stage the changes

The final step is to push the changes to your branch
~git push origin <branch name>~
	

# Pushing Changes
All changes should be pushed to the individual's own branch. (This avoids merging issues.)

# Pulling the master branch to our own branch
Do this when you want to test your work in the main environment. If all is good and well, merge your changes to the master branch.

# Pulling our own branch to the master branch
