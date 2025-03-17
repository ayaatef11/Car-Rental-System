#include"car.h"
#include<iomanip>
Car::Car(Reservation** r, int s) {
	reserve_count = reserve_size = s;
	reserve = new Reservation[reserve_size];
	for (int i = 0; i < reserve_count; i++) {
		reserve[i] = Reservation(*r[i]);

	}
}
Car::Car(int c) {
	reserve_size = c;
	reserve = new Reservation[reserve_size];
}
void Car::setReservations(Reservation** p, int s) {
	//delete[] reserve;
	reserve_size = s;
	reserve = new Reservation[reserve_size];
	for (int i = 0; i < reserve_size; i++) {
		reserve[i] = Reservation(*p[i]);
	}
}
void Car::setReserveSize(int s) {
	if (reserve_size < 0)
		cout << "Invalid number..try again!";
	reserve_size = s;
}
int Car::getReserveSize() {
	return reserve_size;
}
int  Car::getId(){
	return id;
}
bool Car::addReservation(Reservation &r) {
	if (reserve_count < reserve_size) {
		reserve[reserve_count++] = r;
		return true;
	}
	else
		cout << "You exceeded the utomst number of cars ";
	return false;
}
int Car::getReserveCount() {
	return reserve_count;
}
void Car::lessenCount() {
	reserve_count--;
}
bool Car::checkSize() {
	return reserve_count <= reserve_size;
}
bool Car::checkAvailability(Date start_date, Date end_date)
{
	for (int i = 0; i < reserve_count; i++)
	{
		if (overlap(reserve[i].getStartDate(), reserve[i].getEndDate(), start_date, end_date)) {
			availability = 0;
			return false;
		}

	}availability = 1;
	return true;  
}
 istream& operator>>(istream& input, Car& obj) {
	 cout << "\nEnter car informantion(Id/make/model/year): ";
	 input >> obj.id >> obj.make >> obj.model >> obj.year;
	 return input;
 }
 ostream& operator<<(std::ostream& output, const Car& obj) {
	 cout << "\n\t=====CAR INFORMATION=====" << endl;
	 output << "Id: " << obj.id << " | Make: " << obj.make << " | model : " << obj.model << " | Year : " << obj.year;
		
	 if (obj.reserve_count != 0) {
		 for (int i = 0; i < obj.reserve_count; i++) {
			 output << setw(20) << "***Reservation " << i + 1 << " ***"<<endl;
			 output << obj.reserve[i] << endl;
			 output << "Customer id: "<<obj.reserve[i].getCustomerId();
			 
		 }
	 }
	 return output;
 }
bool Car::operator<(Car car)
{
    return reserve_count <car.getReserveCount();
}

bool Car::operator==(Car car)
{
    return  reserve_count ==car.getReserveCount();
}

bool Car::operator>(Car car)
{
	return  reserve_count > car.getReserveCount();

}

Car::~Car() {
	delete[]reserve;
}
Reservation::Reservation(const Reservation& other) {
	startDate = other.startDate;
	endDate = other.endDate;
	c = new Car();
	*c = *(other.c);
}