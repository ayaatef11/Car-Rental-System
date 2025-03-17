
#include <iostream>
#include<cstdlib>
#include<iomanip>
#include<windows.h>
#include<string>
#include"System.h"
#include"person.h"
#include"company.h"
using namespace std;
void printline(string s, bool l = true);//defined in system .cpp
HANDLE cout_handle = GetStdHandle(STD_OUTPUT_HANDLE);
int main()
{
	SetConsoleTextAttribute(cout_handle, 6);
	System s(3,3);
	char ch;
	int c = -1;
	while (c != 0) {
		SetConsoleTextAttribute(cout_handle, 6);
		printline("\t\t\t===CAR RENTAL SYSTEM===");
		printline("where do you want to go :\n\t1.Adding cars and customers");
		printline("\t2.Rent car system\n\t3.Return a car\n\t4.View available cars");
		printline("\t5.View rental history\n\t6.Generate Reports");
		printline("Enter selection: ",false);
		cin >> c;
		system("cls");
		switch (c) {
		case 1:
			SetConsoleTextAttribute(cout_handle, 3);
			do {
				cout << "1-Adding a customer\n2-Adding a car\n3-Return to main menu\n\tEnter choice: ";
				cin >> c;
				switch (c) {
				case 1:
					s.addCustomer();
					break;
				case 2:
					s.addCar();
					break;
				case 3:
					printline("Returning to main menu....");
					break;
				default:
					cout << "Invalid choice...Try again!";
				}
				cout << "Continue in the menu?(y/n)";
				cin >> ch;
			} while (ch != 'n');
			cout << "Returning to main menu.....";
			break;
		case 2:
			SetConsoleTextAttribute(cout_handle, 5);
			s.rentCar();
			break;
		case 3:
			SetConsoleTextAttribute(cout_handle, 4);
			s.returnCar();
			break;
		case 4:
			SetConsoleTextAttribute(cout_handle, 3);
			s.viewAllAvailableCars();
			break;
		case 5:
			SetConsoleTextAttribute(cout_handle, 9);
			s.viewCustomerRentalHistory();
			break;
		case 6:
			SetConsoleTextAttribute(cout_handle, 11);
			s.generateReports();
			break;
		case 0:
			printline("\t\tProgram finished.....Nice time with you:)");
			return 0;
		default:
			printline("Wrong choice...Try again!");
		}
		Sleep(3000);
		system("cls");
	}
}
