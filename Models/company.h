#pragma once
#include"customer.h"
class Company :public Customer {
	string location;
	string company_name;
public:
	istream& readData(istream& input)override;
	ostream& printData(ostream& output) const override;
};
