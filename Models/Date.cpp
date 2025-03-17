#include"Date.h"
#include"string"
Date::Date() :day(0), month(0), year(0) {}
 istream& operator>>(istream& input, Date& obj) {
	 char c = '/';
	 input >> obj.day>>c >> obj.month>>c >> obj.year;
	return input;
}
 ostream& operator<<(std::ostream& output, const Date& obj) {
	 output << obj.day << "/" << obj.month << "/" << obj.year;
	 return output;
 }
int operator -(Date&d1, Date&d2) {
	 Date d;
	int m = d1.month - d2.month;
	int c = d1.day - d2.day;
	d.year= d1.year - d2.year;
	d.month = (m>=0)? m:d.year*12+ m;
	d.day = (c >= 0) ? c : d.month * 30 + c;
	return d.year * 12 * 30 + d.month * 30 + d.day;
 }
bool overlap(Date s1,Date d1,Date s2,Date d2)
{
	if(s2<=d1)
        return true;
   return false;
}
bool Date::operator<(Date d)
{
    return(year<d.year)||(year==d.year&&month<d.month)||(year==d.year&&month==d.month&&day<d.day);
}
bool Date::operator==(Date d)
{
    return year==d.year&&month==d.month&&day==d.day;
}

bool Date::operator>(Date d)
{
    return (year > d.year) || (year == d.year && month > d.month) || (year == d.year && month == d.month && day > d.day);
}
bool Date::operator>=(Date d) {
	return (*this == d) || (*this > d);
}
bool Date::operator<=(Date d) {
	return (*this == d) || (*this < d);
}