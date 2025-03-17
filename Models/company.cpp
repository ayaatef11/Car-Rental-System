#include"company.h"
istream& Company::readData(istream& input)  {
    cout << "Enter customer's details (id, phone number, name, location): ";
    input >> id >> phoneNumber >> company_name >> location;
    return input;
}

ostream& Company::printData(ostream& output) const {
    output << "id: " << id << " | Phone number: " << phoneNumber << endl
        << "Company name: " << company_name << " | Location: " << location << endl;
    return output;
}