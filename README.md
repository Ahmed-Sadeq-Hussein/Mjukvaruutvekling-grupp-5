# Mjukvaruutvekling-grupp5-project
![CI](https://github.com/Ahmed-Sadeq-Hussein/Mjukvaruutvekling-grupp-5/actions/workflows/setup-dotnet.yml/badge.svg)

## Declarations:
I, Julius Norén, declare that I am the sole author of the content I add to this repository. \
I, Sana Subhiyeh, declare that I am the sole author of the content I add to this repository. \
I, Rama Muharam, declare that I am the sole author of the content I add to this repository. \
I, Hannan Khalil, declare that I am the sole author of the content I add to this repository. \
I, Ahmed Hussein, declare that I am the sole author of the content I add to this repository.


## Contributors: 
- Ahmed \
Username: Ahmed-Sadeq-Hussein

- Sana\
Username: SanaSu1

- Hannan\
Username: hannankhalil

- Rama\
Username: RamaTech03

- Julius\
Username: Baesar



---

## What we will implement:
A desktop calculator implemented using C# \
You will be able to enter numbers and operations using keyboard input or by clicking on buttons in the GUI using the cursor. If you have entered a legitimate expression to be calculated, its answer will show up. \
We will design it using the model-view-controller pattern. \
The languages we are going to use are:
- C# 
- XAML

### Features:
- Addition, subtraction, multiplication, division and exponentiation operations
- Euler's number and pi
- Support for brackets

---

## How to compile and run:
To compile and run the calculator, follow these 3 steps:
1. Download the code, this can easily be done in two ways
 - Clone the repository to your local repository on your device by typing `git clone https://github.com/Ahmed-Sadeq-Hussein/Mjukvaruutvekling-grupp-5.git` in the command prompt
 - Download the ZIP file for the calculator, by clicking "download ZIP"\
 ![Download ZIP](https://cdn.discordapp.com/attachments/1221090555405008978/1225146693310218331/image.png?ex=6645a485&is=66445305&hm=02457f23f9c5b0999e34f9691ce9f6959b121b11f956611565b988b204adcdfb&)
2. Open the Solution file named "Calculator-project.sln" in Visual Studio ![Open Solution file](https://cdn.discordapp.com/attachments/1221090555405008978/1225149096503935026/image.png?ex=6645a6c2&is=66445542&hm=781d38c251107457e8fbdb0f286339ae0043f1c077077f40c9b008eeb03c2ec6&)
3. Run the calculator by clicking the green arrow symbol (see image) or by pressing ctrl + F5 ![Running the application](https://cdn.discordapp.com/attachments/1221090555405008978/1225150263602446336/image.png?ex=6645a7d9&is=66445659&hm=84639968f587dd23765e2b4a9cc67fb71a15b817e62a8827be78b18ed7cf5dbf&)

---
## How to run the unit tests and view the results
There are three ways to run the unit tests:

#### First way:

1. Open the project repository in the terminal.
2. Type "dotnet test" in the terminal and press enter, and then all tests will run.
   
#### Second way: 

1. Open "Test Explorer" under "View" manually or by pressing Ctrl+E and then T ![Test Explorer](https://cdn.discordapp.com/attachments/1221090555405008978/1235150186477518900/image.png?ex=66451f00&is=6643cd80&hm=978216aaf56bff87e62edb78c6774c839f6f0a2d9da498b93277b4e7ac1283b2&)
2. Click "Run All Tests In View" manually or by pressing Ctrl+R and then V ![Run tests](https://cdn.discordapp.com/attachments/1221090555405008978/1235155980288000060/image.png?ex=66452465&is=6643d2e5&hm=5c20e7adc3916b6e14ef3e318c58b8c33d5b6dc834cbaa11166d3d5dfcd070f1&)

These three icons at the top show the overall results.
They show:
- The total number of tests
- The total number of passed tests
- The total number of failed tests\
![Overall results](https://cdn.discordapp.com/attachments/1221090555405008978/1235152675189035028/image.png?ex=66452151&is=6643cfd1&hm=49924041eba29e8635be647f9787f3ebf0dd251b2bbbc4d1d16267a5fdb11a4c&)

#### Third way:
1. Open the project in the terminal.
2. Enter `dotnet test`


---
## How to generate code coverage for unit tests
### To run and view the code coverage of the unit tests: 
Open the project repository in the terminal and enter the following:
- `dotnet test --no-build --verbosity normal --collect:"Xplat Code Coverage" --results-directory ./coverage`
- `dotnet tool install -g dotnet-reportgenerator-globaltool`
  - This step is only needed the first time
- `reportgenerator -reports:coverage/**/coverage.cobertura.xml -targetdir:coverlet/reports -reporttypes:"Cobertura"`
- `reportgenerator -reports:coverage/**/coverage.cobertura.xml -targetdir:coverlet/reports -reporttypes:Html`
- `mkdir -p $GITHUB_WORKSPACE/coverage/` \
Now there are two folders in the repository. The coverlet folder includes all of the reports in human readable format. The coverage folder includes the report in xml format.
  ![Code Coverage files](https://cdn.discordapp.com/attachments/1176238610144571453/1239891000072208434/image.png?ex=664491fa&is=6643407a&hm=fa0706e05b13cdd3c517d5712e89f27f5ca5e9a5e22c15f3a7f013c45aa12507&)

### After pushing newly added code to the main branch, a code coverage report is automatically created. To view the results, follow these 3 steps:
1. Head to Github Actions and open the workflow run that you want to view the code coverage report of.\
![Open workflow run](https://cdn.discordapp.com/attachments/1221090555405008978/1238085043763810324/image.png?ex=663e000c&is=663cae8c&hm=158b0692a836635da180521cef9482b3a7e5d8e1bc39756fe8d9abb9b386f0e9&)
2. Scroll all the way down, there you'll find the report which you can download.\
![Download report](https://cdn.discordapp.com/attachments/1221090555405008978/1238086064329986099/image.png?ex=663e0100&is=663caf80&hm=541a4780ab7df10b8a3a7396cad81eeb44ad67a1a03409e8e3f64292a3074459&)
3. Inside the downloaded folder you'll have access to the reports of each file individually and also a summary report of all files.\
![Individual files](https://cdn.discordapp.com/attachments/1221090555405008978/1238083040815878194/image.png?ex=663dfe2f&is=663cacaf&hm=849ad8e850e1cfbf9b19fbe87c097d3825b2b9b08c746c560a0820561f014ef4&)
![Summary files](https://cdn.discordapp.com/attachments/1221090555405008978/1238083085027901450/image.png?ex=663dfe39&is=663cacb9&hm=21e24d1f77d042326ec3892dce0838e9a3f55d16f31ebce229c7cd04a5d069fb&)

---

## How to run a linter
---

### Kanban: https://github.com/users/Ahmed-Sadeq-Hussein/projects/1
### Miro: https://miro.com/app/board/uXjVKbCJa-M=/

