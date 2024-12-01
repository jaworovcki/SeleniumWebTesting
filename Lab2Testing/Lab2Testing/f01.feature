Feature: Login functionality on SauceDemo

  Scenario: Attempt to login with a locked out user
    Given I navigate to "https://www.saucedemo.com/"
    When I enter "locked_out_user" into the username field
    And I enter "secret_sauce" into the password field
    And I click the login button
    Then I should see an error message containing "😑: Sorry, this user has been locked out."
