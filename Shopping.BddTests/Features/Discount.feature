Feature: Membership discounts
  As a shopping customer
  I want my membership discount applied to my cart
  So that I pay the correct final price
 
  Scenario: Regular member receives no discount
    Given the cart subtotal is 1000
    And the membership level is "Regular"
    When the final price is calculated
    Then the final price should be 1000
 
  Scenario: Silver member receives five percent discount
    Given the cart subtotal is 1000
    And the membership level is "Silver"
    When the final price is calculated
    Then the final price should be 950
 
  Scenario: Gold member receives ten percent discount
    Given the cart subtotal is 1000
    And the membership level is "Gold"
    When the final price is calculated
    Then the final price should be 900
 
  Scenario: Zero subtotal remains zero
    Given the cart subtotal is 0
    And the membership level is "Gold"
    When the final price is calculated
    Then the final price should be 0
