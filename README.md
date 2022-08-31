# MPC-MassPropertiesCalculator
The app must calculate the total weight and center of gravity best so far of a list of items with the following conditions.

1. Missing information may be in Center of gravity fields.
2. Quantity can be negative.


  ## Installation Instructions:  
  ### Console Demo 
  1. Go to the release and Download the [AppPackages.zip.](https://github.com/JeanMarcFlamand/MPC-MassPropertiesCalculator/releases)
  2. Extact files.
  3. Lunch the MPC-MassPropertiesCalculator.Installer.appinstaller or the Index.html files.
  

  ## Roadmap:
  Here are the things I would like to accomplish:
 *  **Phase 1 - Minimum**
  - [x] 1. Read data from a .csv file.
     - [x] 1.1 Display the wanted data in console.
  - [X] 2.  Make the calculations taking into account the missing information.
  - [X] 3. Publish a demo console app with test files for those who have no programming knowledge.
  - [ ] 4. Create data layer independent of the user interface.
  - [ ] 5. Add additional user interfaces.
     - [ ] 5.1  WPF (Data Grid).
     - [ ] 5.2  ??? .net MAUI user interface using “DevExpress Data Grid for .NET MAUI” ???

 * **Phase 2 - Nice to Have**
  - [ ] 1. Allow data correction.
  - [ ] 2. Back up the changed data.
  - [ ] 3. Calculation of Inertias.
  - [ ] 4. Create a file that contains the changes made by the user.

## Limitation / Warnings
* **This calculation method was not tested in a recursive process involving a parent-child relationship**
