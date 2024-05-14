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
 ![Download ZIP](https://cdn.discordapp.com/attachments/1221090555405008978/1225146693310218331/image.png?ex=66332f85&is=6631de05&hm=d4cc1e61e1d423c2ed83277ddc81bf654b497d48024639c5e49707a291a87dca&)
2. Open the Solution file named "Calculator-project.sln" in Visual Studio ![Open Solution file](https://cdn.discordapp.com/attachments/1221090555405008978/1225149096503935026/image.png?ex=663331c2&is=6631e042&hm=c5237a3e0f408967294e9024a8ed0bdae2f41c8b18101d72c432744b24e2d452&)
3. Run the calculator by clicking the green arrow symbol (see image) or by pressing ctrl + F5 ![Running the application](https://cdn.discordapp.com/attachments/1221090555405008978/1225150263602446336/image.png?ex=663332d9&is=6631e159&hm=7b18bf0cdf22f13953c2b47852bdc796c90785391f5273462899452881cb6ac6&)

---
## How to run the unit tests and view the results
There are two ways to run the unit tests:

# First way:

1. Open the cloned repository folder, right-click anywhere, and then select "View more alternatives," and then click on "Open in Terminal."
2. Type "dotnet test" in the terminal and press enter, and then all tests will run.
   
# Second way: 

1. Open "Test Explorer" under "View" manually or by pressing Ctrl+E and then T ![Test Explorer](https://cdn.discordapp.com/attachments/1221090555405008978/1235150186477518900/image.png?ex=663352c0&is=66320140&hm=e58fa10feb842d702489e66d34eb2c2cb26f1cb94bbe9ffd5e6b22694dffb670&)
2. Click "Run All Tests In View" manually or by pressing Ctrl+R and then V ![Run tests](https://cdn.discordapp.com/attachments/1221090555405008978/1235155980288000060/image.png?ex=66335825&is=663206a5&hm=a97c79d1ee57f79f5511d31a60e4d1299da90a3c4e22444c347e96f24d37e135&)

These three icons at the top show the overall results.
They show:
- The total number of tests
- The total number of passed tests
- The total number of failed tests\
![Overall results](https://cdn.discordapp.com/attachments/1221090555405008978/1235152675189035028/image.png?ex=66335511&is=66320391&hm=a0b4e057aeba17d53cebfbc31965c294e885db22d4aad8c551f74fa8ec32b4d8&)


---
## How to generate code coverage for unit tests
### To run and view the code coverage of the unit tests,Open the project repository in the terminal and enter the following:
- dotnet test --no-build --verbosity normal --collect:"Xplat Code Coverage" --results-directory ./coverage
- dotnet tool install -g dotnet-reportgenerator-globaltool
  - This step is only needed the first time
- reportgenerator -reports:coverage/**/coverage.cobertura.xml -targetdir:coverlet/reports -reporttypes:"Cobertura"
- reportgenerator -reports:coverage/**/coverage.cobertura.xml -targetdir:coverlet/reports -reporttypes:Html
- mkdir -p $GITHUB_WORKSPACE/coverage/ \
Now there are two files in the repository. The coverlet folder includes all of the reports in human readable format. The coverage folder includes the report in xml format.
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

