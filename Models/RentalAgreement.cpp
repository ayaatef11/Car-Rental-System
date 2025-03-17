#include"RentalAgreement.h"
rentalAgreement::rentalAgreement():rentalPeriod(0),rentalPrice(0){
//c = new Car;
}
int rentalAgreement::getRentalPeriod(){
	return rentalPeriod;
}
double rentalAgreement::getRentalRate(){
	return rentalRate;
}
double rentalAgreement::getInsuranceCharges(){
	return insuranceCharges;
}
double rentalAgreement::getRentalPrice() {
     rentalPrice=rentalPeriod * getRentalRate() + getInsuranceCharges();
	 return rentalPrice;
}
double rentalAgreement::operator +(int price)//pay the second part of bill
{
    return price + getRentalPrice();
}
bool rentalAgreement::operator<(rentalAgreement rentalAgreement) {
    return getRentalPrice() < rentalAgreement.getRentalPrice();
}
bool rentalAgreement::operator>(rentalAgreement rentalAgreement) {
    return getRentalPrice() > rentalAgreement.getRentalPrice();
}
bool rentalAgreement::operator==(rentalAgreement rentalAgreement) {
    return getRentalPrice() ==rentalAgreement.getRentalPrice();
}
istream& operator >>(istream& in, rentalAgreement& obj) {
	cout << "Enter rental period: ";
	in >> obj.rentalPeriod;
	cout << "Enter rental rate: ";
	in >> obj.rentalRate;
	cout << "Enter insurance charges: ";
	in >> obj.insuranceCharges;
	return in;
}
 ostream& operator <<(ostream&out,rentalAgreement&obj) {
	 out << "\n Rental period: " << obj.getRentalPeriod()<<" |Rental Price: " << obj.getRentalPrice()<<
		" |Insurance charges: " << obj.getInsuranceCharges()<<" |Rental rate: " << obj.getRentalRate();
	 return out;
 }