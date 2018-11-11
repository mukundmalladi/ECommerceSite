#### ECommerceSite
Welcome to Ecommerce site. 
This is a basic Ecommerce web application where users can register, login view products, add products to cart and finally checkout.
This web application is just a skeleton to huge Ecommerce application.
The  application is developed using .Net Stack.
The stack contains Sql Server 2017, DotNet framework targeting 4.6.1

### **Stacks**
I used many open source libraries to build up the application. The following are the once :
1. Dapper along with petapoco as the ORM's for fetching and saving the data.
2. Fluent Migrator for having control of the data base migrations.
3. Elastic Search for handling the transactions related to adding data to cart and fetching from cart.
4. For client side I used Jquery, and Javascript
5. For client side validations I used the validation offered by Javascript, bootstrap and Jquery
6. The view and desgin is done using bootstrap 4.

The web application does have a credit card info but technically we should not be storing credit card info since that's not compliant.
In future we can interact with third party services like paypal, Strip etc. Should be a easy code change
We can also work with shipping vendors like fedex etc to track sites - but that's a long shot.

### **Notes**
The code is written in very simple format. Standard coding practices are not applied in some cases. Refactoring is one of the todo on my list.
The project on the whole can be improved a lot but adding lot of functionalities.

### Some of the **TODO's** on my list are:
1. Adding view my orders screen under user name
2. Ability for web application admin to login and add products to database directly instead if via a database update
3. Adding more products to the application
4. Move Elastic search to it's own interface and refactor the code
5. Many more refactoring.....

### **To set up locally**
**Prerequisites:*
1. Elastic Search
2. Visual Studio 2017(community edition works)
3. Sql Server 2017 (developer edition works)

1. Clone the project locally
2. Build it - make sure the nuget packages are restored.
3. Setup IIS to the webconfig (or)
4. Once build is done hit f5 to run the application
5. Need to inserts records manually to database to Inventory and products table.
6. The register, login viewing products, adding to cart and checkout should all work as expected.

Here is few screen shots of the projects

![Image](/EcommerceMvc/Images/RegisterPage.PNG?raw=true "Register View Page")
![Image](/EcommerceMvc/Images/LoginPage.PNG?raw=true "Login View Page")
![Image](/EcommerceMvc/Images/LandingPage.PNG?raw=true "Landing View Page")
![Image](/EcommerceMvc/Images/AddToCart.PNG?raw=true "Add To Cart View Page")
![Image](/EcommerceMvc/Images/CheckoutModel.PNG?raw=true "Checkout View Page")
![Image](/EcommerceMvc/Images/InteractivePriceUpdate.PNG?raw=true "InteractivePriceUpdate Page")

**PS**: Please ignore my typo's or grammatical errors.
