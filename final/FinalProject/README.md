* Just follow the prompts
* A user can sign up with name, password and user type(admin or customer)
* A user who has previously signed up can login with name and password
* An admin can Add Products, View Products, Update Products, and Purchase Products
* A customer can only View Products and Purchase Products
* Because a database (file) was not created to store products it would be better to test as an admin
* To update and purchase products you need to view the individual products to collect the product id, which will be used to find the product. Viewing all products does not show their id.
* To see invoice after purchase use the view option. You can purchase more than one item. If you try to purchase more than is available, the error is handled gracefully.
* Not all invalid input errors were accounted for because of time and to make the code look simpler. Comments were added to show where some of these could have been handled.
* Errors handled includes: invalid input for sign up/login, customer trying to access admin route, id not found and user not found.
* We can only update the price of a product for now. 