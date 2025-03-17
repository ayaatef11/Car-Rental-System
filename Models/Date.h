#pragma once
#include<iostream>
using namespace std;
struct Date {
	int day=0;
	int month=0;
	int year=0;
public:
	Date();
friend istream& operator>>(istream&, Date&);
friend std::ostream& operator<<(std::ostream&, const Date&);
 friend int operator -(Date&, Date&);
 bool operator<(Date);
 bool operator==(Date);
 bool operator>(Date);
 bool operator>=(Date);
 bool operator<=(Date);
};