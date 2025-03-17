#include"car.h"
#include<iomanip>
#pragma once
#include<iostream>
#include"reservation.h"
using namespace std;

public class  Car {
	public int id{ get; set; }
	public string make { get; set; }
	public string model { get; set; }
	public int year { get; set; }
	public bool availability { get; set; }
	public Reservation* reserve { get; set; }
	public int reserve_count { get; set; }
	public int reserve_size { get; set; }

	Car(Reservation** r, int s) {
	reserve_count = reserve_size = s;
	reserve = new Reservation[reserve_size];
	for (int i = 0; i<reserve_count; i++) {
		reserve[i] = Reservation(*r[i]);
         }
     }

Car(int c) {
	reserve_size = c;
	reserve = new Reservation[reserve_size];
}

	void setReservations(Reservation** p, int s)
	{
		//delete[] reserve;
		reserve_size = s;
		reserve = new Reservation[reserve_size];
		for (int i = 0; i < reserve_size; i++)
		{
			reserve[i] = Reservation(*p[i]);
		}
	}
	void  setReserveSize(int s)
	{
		if (reserve_size < 0)
			cout << "Invalid number..try again!";
		reserve_size = s;
	}

	int  getReserveSize()
	{
		return reserve_size;
	}

	int getId()
	{
		return id;
	}
	bool  addReservation(Reservation &r)
	{
		if (reserve_count < reserve_size)
		{
			reserve[reserve_count++] = r;
			return true;
		}
		else
			cout << "You exceeded the utomst number of cars ";
		return false;
	}


	int getReserveCount()
	{
		return reserve_count;
	}

	void lessenCount()
	{
		reserve_count--;
	}

	bool checkSize()
	{
		return reserve_count <= reserve_size;
	}

	bool checkAvailability(Date start_date, Date end_date)
	{
		for (int i = 0; i < reserve_count; i++)
		{
			if (overlap(reserve[i].getStartDate(), reserve[i].getEndDate(), start_date, end_date))
			{
				availability = 0;
				return false;
			}

		}
		availability = 1;
		return true;
	}

	istream& operator>>(istream& input, Car& obj) {
	 cout << "\nEnter car informantion(Id/make/model/year): ";
	 input >> obj.id >> obj.make >> obj.model >> obj.year;
	 return input;
 }

ostream& operator <<(std::ostream& output, const Car& obj)
{
	cout << "\n\t=====CAR INFORMATION=====" << endl;
	output << "Id: " << obj.id << " | Make: " << obj.make << " | model : " << obj.model << " | Year : " << obj.year;

	if (obj.reserve_count != 0)
	{
		for (int i = 0; i < obj.reserve_count; i++)
		{
			output << setw(20) << "***Reservation " << i + 1 << " ***" << endl;
			output << obj.reserve[i] << endl;
			output << "Customer id: " << obj.reserve[i].getCustomerId();

		}
	}
	return output;
}
bool  operator <(Car car)
{
	return reserve_count < car.getReserveCount();
}

bool  operator ==(Car car)
{
	return reserve_count == car.getReserveCount();
}

bool  operator >(Car car)
{
	return reserve_count > car.getReserveCount();

}


~Car()
{
	delete[] reserve;
}



};
bool overlap(Date s1, Date d1, Date s2, Date d2);

Reservation::Reservation(const Reservation& other) {
	startDate = other.startDate;
endDate = other.endDate;
c = new Car();
*c = *(other.c);
}


