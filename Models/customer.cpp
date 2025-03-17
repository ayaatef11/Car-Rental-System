#include"customer.h"
Customer::Customer(int c){
	size_reserve = c;
	x = new Reservation[size_reserve];
	}
Customer::Customer(Reservation**reserveArr, int s) {
	count_reserve=size_reserve = s;
	x = new Reservation[size_reserve];
	for (int i = 0; i < size_reserve; i++) {
		x[i] = Reservation(*reserveArr[i]);
	}
}
int Customer::getId() {
	return id;
}
int Customer::getReseveSize() {
	return size_reserve;
}
bool Customer::checkSize() {
	return count_reserve <= size_reserve;
}
bool Customer::addReservation(Reservation &r) {
	if (count_reserve == size_reserve) {
		cout << "You exceeded the utmost number of reservations..You can't add any more";
		return false;
	}
	else {
		//cout<<"Enter "
		x[count_reserve++] = r;
		return true;
	}
}
void Customer::deleteReservation(Reservation& r) {
	for (int i = 0; i < count_reserve; i++) {
		if (x[i] == r) {
			 x[i]= x[count_reserve - 1] ;
			count_reserve--;
		}
	}
}
bool Customer::operator<(Customer &customer)
{
	return count_reserve < customer.getReseveSize();
}
bool Customer::operator==(Customer &customer)
{
	return count_reserve == customer.getReseveSize();
}
bool Customer::operator>(Customer& customer)
{
	return count_reserve > customer.getReseveSize();
}
 istream& operator>>(istream& input, Customer& obj) {
	 return obj.readData(input);
 }

 ostream& operator<<(ostream& output, const Customer& obj) {
	 return obj.printData(output);
 }

 Customer::~Customer() {
	 delete[] x;
 }
 