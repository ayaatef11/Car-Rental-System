#pragma once
#include<iomanip>
#include"car.h"
#include"customer.h"
#include"person.h"
#include"company.h"
#include"reservation.h"
class System {
    Reservation reservation;
    int carSize = 0;
    int carCount = 0;
    Car* car;
    int customerSize= 0;
    int customerCount = 0;
    Customer** customer;
    reservationStatus stat;
    int Search_car(int);
    int search_customer(int);
    void setCarSize(int);
    void setCustomerSize(int);
public:
    System(int,int);
    void addCar();
    void addCustomer();
    void rentCar();
    void returnCar();
    void viewAllAvailableCars();
    void viewCustomerRentalHistory();
    void generateReports();
    ~System();
};
