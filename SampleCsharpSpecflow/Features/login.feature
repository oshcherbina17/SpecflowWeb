Feature: SauceDemo Login
    As a user of SauceDemo
    I want to be able to log in using my credentials
    So that I can access the product page

Scenario Outline: Logging in with valid credentials
    Given I am on the SauceDemo login page
    When I enter valid credentials '<Username>' and '<Password>'
    Then I should be redirected to the product page

Examples:
    | Username       | Password     |
    | standard_user  | secret_sauce |
