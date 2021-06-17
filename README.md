# PrimeFactorization
Console application that proccesses numbers from a file and for each number calculates its prime factorization.


## Input parameters
Application takes 2 input parameters from command line. 
At least one is required.
First parameter is path to the file that is going to be processed.
The second parameter is path to directory, if it's not specified it's the current working directory.
All the paths can be either abosulute or relative to the current working directory.

## Example usage in Command Line
PrimeFactorization.ConsoleApp.exe C:\files\files.txt outputFiles  
PrimeFactorization.ConsoleApp.exe C:\files\files.txt  

## Notes
If a line from file cannot to parsed to ulong type "error" line will be appended in the result files.

### To stop processing number use Ctrl^C.
