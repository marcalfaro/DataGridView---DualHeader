# DataGridView---DualHeader
Create Dual Headers or Group Headers in your DataGridView control

I have searched online for a solution to create dual or multiple headers for the DataGridView control and so far, they don't suit my requirements.
I needed to add customizable "group headers" that spans above their "child" column headers, as well as having the flexibility to add more child or group columns. 

Some examples online either:
  1. Adds datacolumns having same names, and then merge those columns having similar names or,
  2. Merging columns by predefined pairs.
  
Those examples are good BUT it doesn't give you the flexibility of adding more columns under specific "GROUP HEADERS".

Furthermore, all those examples exhibit this weird scrolling problem where the painted new header disappears if the default child column disappears from the horizontal scrolling view:

![scrollproblem](https://user-images.githubusercontent.com/5296677/71608595-3f5b9000-2bbd-11ea-8f49-5007d5f2497d.png)

So I have created my own solution that:
 1. Addresses this "disappearing" header problem upon scrolling horizontally. 
 2. You can freely customize the style and add as many group headers as you want. 
 
![myheaders](https://user-images.githubusercontent.com/5296677/71608726-37e8b680-2bbe-11ea-84e0-2b2fdce1109b.png)

Feel free to download and improve it.

Thanks!

Marc
