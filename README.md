# ASP.NET Core: Exception Handling
This is the repository for the LinkedIn Learning course ASP.NET Core: Exception Handling. The full course is available from [LinkedIn Learning][lil-course-url].

![ASP.NET Core: Exception Handling][lil-thumbnail-url] 

When things go bad, good programmers are ready. Exception handling allows you to ensure your applications respond to errors with grace. With the right exception handling, your user’s experience will never be disrupted. This course teaches the basics of handling exceptions in the ASP.NET Core framework. Instructor Ervis Trupja starts with an overview of exception handling and then works through the various techniques to catch exceptions in ASP.NET. Learn how to use try-catch-finally to identify and handle errors, using both built-in and custom exception types. Then discover how to handle errors more efficiently with global handlers, and add exception filters to your .NET Core applications to apply global policies to unhandled exceptions.

## Instructions
This repository has branches for each of the videos in the course. You can use the branch pop up menu in github to switch to a specific branch and take a look at the course at that stage, or you can add `/tree/BRANCH_NAME` to the URL to go to the branch you want to access.

## Branches
The branches are structured to correspond to the videos in the course. The naming convention is `CHAPTER#_MOVIE#`. As an example, the branch named `02_03` corresponds to the second chapter and the third video in that chapter. 
Some branches will have a beginning and an end state. These are marked with the letters `b` for "beginning" and `e` for "end". The `b` branch contains the code as it is at the beginning of the movie. The `e` branch contains the code as it is at the end of the movie. The `main` branch holds the final state of the code when in the course.

When switching from one exercise files branch to the next after making changes to the files, you may get a message like this:

    error: Your local changes to the following files would be overwritten by checkout:        [files]
    Please commit your changes or stash them before you switch branches.
    Aborting

To resolve this issue:
	
    Add changes to git using this command: git add .
	Commit changes using this command: git commit -m "some message"


### Instructor

Ervis Trupja 
                            
Software Developer

                            

Check out my other courses on [LinkedIn Learning](https://www.linkedin.com/learning/instructors/ervis-trupja).

[lil-course-url]: https://www.linkedin.com/learning/asp-dot-net-core-exception-handling
[lil-thumbnail-url]: https://cdn.lynda.com/course/2880216/2880216-1622572047935-16x9.jpg
