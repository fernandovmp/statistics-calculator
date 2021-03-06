# Statistics calculator
> Mobile statistics calculator app

[![Build status](https://build.appcenter.ms/v0.1/apps/c5583ce0-cb27-4a77-988f-258230bb6d46/branches/master/badge)](https://appcenter.ms)

<img src="Screenshots/Screenshot_01.png" width=33% /><img src="Screenshots/Screenshot_02.png" width=33% hspace=2/><img src="Screenshots/Screenshot_03.png" width=33%/>
<img src="Screenshots/Screenshot_04.png" width=33% /><img src="Screenshots/Screenshot_05.png" width=33% hspace=2/><img src="Screenshots/Screenshot_06.png" width=33%/>

#### Leia em [português](./LEIAME.md)

# Table of Content
- [Why?](#why?)
- [Installers](#installers)
- [Features](#features)
- [Getting started](#getting-started)
- [Contribute](#contribute)
- [Statistics Class](./StatisticsCore/)

# Why?
This app is part of my personal portfolio, so i would be grateful for any feedback about the project, code, concepts or other aspect. Also i need a calculator to statistics class.

# Installers
The android installer (5.0 Lolipop ~ 9.0 Pie) can be found [here](https://drive.google.com/open?id=1GyfaEhdp7MEbBXaw7EFToQjcOojnAKMX).

# Features
- [x] Sum of all items values of the sample
- [x] Sum of squares of all items values of the sample
- [x] Mean, median and mode calcule
- [x] Population and sample standard deviation
- [x] Population and sample variance
- [x] Normal distribution density
- [ ] Frequency table
- [ ] Export and import sample
- [x] Binomial 
- [x] Poisson
- [x] Linear Regression

 
# Getting started
## Requiriments
Require Visual Studio and Xamarin installed to open this project.
## Installation
Clone this repository: \
`$ git clone https://github.com/fernandovmp/statistics-calculator.git` \
Open the `StatisticsCalculator.sln` file, that can be found in the root of project, with the Visual Studio.

## Build locally
Create a json file named "secrets.json" in StatisticsCalculator shared project with the following content:
```json
{
    "AndroidAppSecret": "{App center android app secret}"
}
```

Or comment the AppCenter start method in `App.xaml.cs`

### [Statistics Class](./StatisticsCore/)

# Contribute
To contribute fork this repository and after make the changes do a pull request. Any contribution is wellcome.

The code style is the same as [.NET Foundation](https://github.com/dotnet/corefx/blob/master/Documentation/coding-guidelines/coding-style.md)
