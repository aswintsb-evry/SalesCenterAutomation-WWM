﻿Feature: CockPit
	I want to able to verify dashboard scenarios

Background: 
	Given I am logged in
	
@smoke  @WWM-8411 @CockPit @WW_CP_001
Scenario: Verify Captured Leads, Open Opportunities, Leads to Qualify cards are displayed on dashboard
    Then Verify the Leads opportunities and Leads to Qualify cards are displayed on dashboard

@smoke @WWM-8412 @CockPit @WW_CP_002
Scenario: Verify default dispay of Records with Overdue Next Action Dates on dashboard
    Then Verify the  default dispay of Records with Overdue Next Action Dates on dashboard

@smoke @WWM-8414 @CockPit @WW_CP_002
Scenario: Verify default dispay of Upcoming Follow-Ups on dashboard
    Then Verify the default dispay of Upcoming Follow-Ups on dashboard
