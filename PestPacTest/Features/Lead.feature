﻿@Lead

Feature: Lead
	I want to able to verify leads scenarios

Background: 
	Given I am logged in



@smoke @Leads @WW_LD_001
Scenario Outline: Verify Display of Leads Page through sales center menu
    When Mouse hover on sales center side menu
    And Click on Leads link
    Then Leads page should be displayed
  
 

@smoke @Leads @WW_LD_002
Scenario Outline: Verify user can create and delete a lead   
    When Click on plus icon
    And  Click on Add Lead button
    Then Add Lead details page should be displayed
    And Enter the lead details <FirstName> <LastName> <CompanyName> <Email> 
    And Select the SalesTeam <SalesTeam>
    And Select the Owner <Owner>
    And Select the sales funnel <SalesFunnel>
    When Click on Save button
    Then Lead created validation message should be displayed <ValidationMessage>
    And  Click on search icon
    And  Enter the lead name <LeadName> and click on search icon
    When Delete the lead
    Then Lead deleted confirmation message should be displayed <DeleteConfirmMessage>
    
 Examples:  
     | FirstName        | LastName | CompanyName  | Email              | SalesTeam                  | Owner      | SalesFunnel                 | ValidationMessage | LeadName    | DeleteConfirmMessage |
     | Automation user2 | Test2    | autocompany2 | autouser@gmail.com | Secondary south sales Team | Unassigned | Required Contract & Payment | Lead created      | autocompany | Lead deleted.        |
	 


@smoke @Leads @WW_LD_002
Scenario Outline: Verify user can create lead and convert to opportunity
    When Click on plus icon
    And  Click on Add Lead button
    Then Add Lead details page should be displayed
    And Enter the lead details <FirstName> <LastName> <CompanyName> <Email> 
    And Select the SalesTeam <SalesTeam>
    And Select the Owner <Owner>
    And Select the sales funnel <SalesFunnel>
    When Click on Save button
    Then Lead created validation message should be displayed <ValidationMessage>
    And Click on Service expand icon
    And Click on Add Serivces button
    And Select the services <Services>
    When Click on Add services button in slider
    Then Service should be successfully added
    And Click on Close services and product button
    When Click on convert to opportunity button
    When Select the lead details <OwnerName> <FunnelStage>  
    Then validation message should be displayed <OpportunityCreated>
 
 Examples:  
     | FirstName       | LastName | CompanyName   | Email              | SalesTeam                  | Owner      | SalesFunnel                 | ValidationMessage | LeadName   | Services            | FunnelStage | Ownername  | OpportunityCreated  | OpportunityDeleteConfirmMessage | OpportunityName |
     | Automation Labs | Labs01   | autocompany01 | autouser@gmail.com | Secondary south sales Team | Unassigned | Required Contract & Payment | Lead created      | Automation | ANT- Ant Treatments | Stage1      | Unassigned | Opportunity created | Opportunity Deleted             | Automation Labs |


@smoke @Leads @WW_LD_003
Scenario Outline: Verify user able to create new opportunity directly 
    When Click on plus icon
    And  Click on Add Lead button
    Then Add Lead details page should be displayed
    And Enter the lead details <FirstName> <LastName> <CompanyName> <Email> 
    And Select the SalesTeam <SalesTeam>
    And Select the Owner <Owner> 
    And Select the sales funnel <SalesFunnel>
    When Click on Save button
    Then Lead created validation message should be displayed <ValidationMessage>
    And  Click on Service expand icon
    And Click on Add Serivces button
    And Select the services <Services>
    When Click on Add services button in slider
    Then Service should be successfully added
    And Click on Close services and product button
    When Click on plus icon
    And  Click on Create opportunity button
    And Search the lead <LeadName>
    When Click on Create opportunity button in create opportunity page  
    When Select the lead details <OwnerName> <FunnelStage>  
    Then validation message should be displayed <OpportunityCreated>
 

 Examples:  
     | FirstName       | LastName | CompanyName   | Email              | SalesTeam                  | Owner      | SalesFunnel                 | ValidationMessage | Services            | FunnelStage | Ownername  | OpportunityCreated  | OpportunityDeleteConfirmMessage | OpportunityName | LeadName      |
     | Automation Labs | Labs02   | autocompany02 | autouser@gmail.com | Secondary south sales Team | Unassigned | Required Contract & Payment | Lead created      | ANT- Ant Treatments | Stage1      | Unassigned | Opportunity created | Opportunity Deleted             | Automation Labs | Automation    |



@smoke @Leads @WW_LD_004
Scenario Outline: Verify User Can Add a Contract to a Lead
    When Click on plus icon
    And Click on Add Lead button
    Then Add Lead details page should be displayed
    And Enter the lead details <FirstName> <LastName> <CompanyName> <Email> 
    And Select the SalesTeam <SalesTeam>
    And Select the Owner <Owner> 
    And Select the sales funnel <SalesFunnel>
    When Click on Save button
    Then Lead created validation message should be displayed <ValidationMessage>
    And  Click on Service expand icon
    And  Click on Add Serivces button
    And  Select the services <Services>
    When Click on Add services button in slider
    Then Service should be successfully added
    And Click on Close services and product button
    When Click on send contract button
    Then Create contract slider should be displayed
    And  Select contract template <Template> and click on launch form to complete button  
    And  Click on complete form button
    When Click on proceed button
    Then Contract should be successfully added

Examples:  
     | FirstName       | LastName | CompanyName   | Email              | SalesTeam                  | Owner      | SalesFunnel                 | ValidationMessage | Services            | Template                 |
     | Automation Labs | Labs03   | autocompany03 | autouser@gmail.com | Secondary south sales Team | Unassigned | Required Contract & Payment | Lead created      | ANT- Ant Treatments | Residential Service Form |


@smoke @WWM-8426 @Leads @WW_LD_005
Scenario Outline: Ensure User Can Re-Open a Disqualified Lead
    When Mouse hover on sales center side menu
    And Click on Leads link
    Then Leads page should be displayed
    And  Click on filters button
    And Click on clear filter button
    And  Click on filters button
    And  Select the lead status <LeadStatus>
    When Click on Apply button
    Then All the disqualified leads should be diplayed
    And Click on three dots icon for disqualified lead
    And Select the reopen option
    And Select Qualify option in popup <Qualify>
    When Click on Save button in Re-Open Lead popup
   # Then Lead should be successfully reopened validation message should be displayed

Examples:  
     | LeadStatus   | Qualify  | 
     | Disqualified | Qualify  | 

