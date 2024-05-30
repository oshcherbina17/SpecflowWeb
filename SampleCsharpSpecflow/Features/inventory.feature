Feature: Add and Remove Items from Cart
    As a logged-in user on SauceDemo
    I want to be able to add items to my cart and remove them
    So that I can manage my shopping cart items effectively

Scenario Outline: Add and remove items from cart
    Given I am logged in as a standard user
    When I press the add to cart button for "<item>"
    Then the "<item>" is correctly added to the cart
    When I press the remove button for "<item>"
    Then the "<item>" is correctly removed from the cart

Examples:
    | item               |
    | Sauce Labs Onesie  |
    | Sauce Labs Bike Light |
