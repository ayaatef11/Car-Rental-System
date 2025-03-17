#include"reservation.h"
Reservation::Reservation() {
	c = nullptr;
	m_customer = nullptr;
	customerId = 0;
}
Reservation::Reservation(Car* p) {
	c = p;
}
void Reservation::setStatue(reservationStatus s) {
	status = s;
}
string Reservation::getStatue() {
	return status;
}
int Reservation::getCustomerId() {
	return customerId;
}
int  Reservation::getCarId() {
	return carId;
}
Invoice Reservation::getInvoice() {
	return invoice;
}
void Reservation :: setCar(Car*p) {
	c = p;
}
Date Reservation::getStartDate() {
	return startDate;	
}
Date Reservation::getEndDate() {
	return endDate;
}
int Reservation::computePeriod() {
	
	return  endDate - startDate;

}
void Reservation::readCarId() {
	cout << "Enter car id: ";
	cin >> carId;
}
void Reservation::readCustomerName() {
	cout << "Enter customer id: ";
	cin >> customerId;
}
void Reservation::readInvoice() {
	cout << "Invoice details: ";
	cin>>invoice;
	
}
istream& operator>>(istream&in, Reservation& obj) {
	cout << "Enter reservation details: ";
	cout << "\nEnter start Date(day/month/year): ";
	in >> obj.startDate;
	cout << "Enter End Date(day/month/year): ";
	in >> obj.endDate;
	return in;
}
ostream& operator<<(ostream&out, Reservation&obj) {
	out<< "\nStart Date: " << obj.startDate << "  |End Date: " << obj.endDate << "\nInvoice details: " << obj.invoice;
	return out;

}
bool Reservation::operator<(Reservation reservation)
{
return invoice.calculateTotalAmountDue()<reservation.getInvoice().calculateTotalAmountDue();
}

bool Reservation::operator==(Reservation reservation)
{
	return invoice.calculateTotalAmountDue() ==reservation.getInvoice().calculateTotalAmountDue();
}

bool Reservation::operator>(Reservation reservation)
{
	return invoice.calculateTotalAmountDue() > reservation.getInvoice().calculateTotalAmountDue();
}

	




