# BomViewer
Test task to demonstrate skills on 22.11.2021


## Task
The challenge is essentially a data manipulation problem that is very typical in ERP systems. There are two data files attached to this email (bom.csv and part.csv) that are in csv format.  You can convert the data files to whatever format you feel comfortable with. I suggest SQL Server.

The bom.csv file describes how the part numbers in the part.csv file are interrelated. Please use the BOM file to construct a tree view showing all the parts in the BOM file.  There should be 5 levels in your tree view if the code is working properly. A BOM is a Bill of Material. You should do some research to understand what an indented multilevel bill of material is.

Once you have done the tree view, please add a data grid view that shows the component parts of the part that is currently selected in the tree view.  If the part has no components, the data grid view should be blank. Please include the following columns in the data grid view

· COMPONENT_NAME
· PART_NUMBER
· TITLE
· QUANTITY
· TYPE
· ITEM
· MATERIAL

COMPONENT_NAME comes from the BOM file but the rest of the data must come from the PART file.

Most of the COMPONENT_NAME data crosses over to a record in the PART file with NAME= COMPONENT_NAME.  If there is no record in the PART file, you can leave the fields blank.
The form should look something like the screenshot below when you are done.
Note that there are two buttons:
· Populate Data in Tree.  This will populate the tree view and disable it once the tree view is fully populated
· Exit from Application.
