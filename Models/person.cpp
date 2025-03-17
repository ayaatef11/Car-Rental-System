#include"person.h"
#include<iomanip>
#include<string>
 istream& Person ::readData(istream& input)  {
     cout << "Enter customer's details (id, phone number, full name, address): ";
     input >> id >> phoneNumber >> full_name >> address;
     return input;
 }
 ostream& Person::printData(ostream& output) const  {
     output << "Customer's details: " << endl << "id: " << id << " | Phone number: " << phoneNumber << endl;
     output << "Full name: " << full_name << " | Address: " << address << endl;
     return output;
 }