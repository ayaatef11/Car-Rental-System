#include"invoice.h"
Invoice::Invoice():taxes(0), rentalCharges(0), totalAmountDue(0) {
	agreement = new rentalAgreement;
}
Invoice::Invoice(rentalAgreement*p){
	agreement = new rentalAgreement;
	agreement = p;
}
void Invoice::setAgreement(rentalAgreement* p) {
	agreement = new rentalAgreement;
	agreement = p;
}
void Invoice::readtaxes() {
	cout << "\nEnter Taxes: ";
	cin >> taxes;
}
double Invoice::getRentalCharges() {
	return rentalCharges;
}
double Invoice::calculateTotalAmountDue() {
	totalAmountDue = rentalCharges + agreement->getRentalPrice()+taxes;
	return totalAmountDue;
}
istream& operator>>(istream&in, Invoice&v){
	in >> *(v.agreement);
	cout << "Enter rental charges: ";
	in >> v.rentalCharges;
	cout << "Enter Taxes: ";
		in >> v.taxes;
	return in;
}
ostream& operator <<(ostream& out, Invoice& v) {
	out << *(v.agreement)<<" |rentalCharges: "<<v.rentalCharges << " | Taxes: " << v.taxes;
	return out;
}
bool Invoice::operator<(Invoice invoice)
{
	return calculateTotalAmountDue()< invoice.calculateTotalAmountDue();
}
bool Invoice::operator==(Invoice invoice)
{
	return calculateTotalAmountDue()==invoice.calculateTotalAmountDue();
}
bool Invoice::operator>(Invoice invoice)
{
	return calculateTotalAmountDue()> invoice.calculateTotalAmountDue();
}
	
