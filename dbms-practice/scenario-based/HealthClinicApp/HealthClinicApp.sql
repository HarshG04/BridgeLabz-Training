-- CREATE DATABASE HealthClinicApp;
-- USE HealthClinicApp;

GO
CREATE TABLE Patients(
	PatientID INT IDENTITY(1,1) PRIMARY KEY,
	PatientName VARCHAR(50) NOT NULL,
	DOB DATE NOT NULL,
	Phone VARCHAR(10) UNIQUE NOT NULL,
	-- Email VARCHAR(50) UNIQUE  NULL,	-- How to create a Unique Column With Multiple Null Values
	BloodGroup VARCHAR(5) NOT NULL CHECK (BloodGroup IN ('A+', 'A-', 'B+', 'B-', 'AB+', 'AB-', 'O+', 'O-')),
	Address VARCHAR(100) NOT NULL,
	Password VARCHAR(10) NOT NULL DEFAULT 'PatPass',
	CreatedAt DATETIME DEFAULT GETDATE() NOT NULL,
	UpdatedAt DATETIME DEFAULT GETDATE() NOT NULL
);

GO
CREATE TABLE Specialties(
	SpecialtyID INT IDENTITY(1,1) PRIMARY KEY,
	SpecialtyName VARCHAR(50) UNIQUE NOT NULL
);

GO
CREATE TABLE Doctors(
	DoctorID INT IDENTITY(1,1) PRIMARY KEY,
	DoctorName VARCHAR(50) NOT NULL,
	Phone VARCHAR(10) UNIQUE NOT NULL,
	-- Email VARCHAR(50) UNIQUE  NULL, -- How to create a Unique Column With Multiple Null Values
	Password VARCHAR(20) NOT NULL DEFAULT 'DocPass',
	SpecialtyID INT DEFAULT NULL,
	ConsultationFee DECIMAL(10,2) NOT NULL,
	IsActive BIT DEFAULT 1,
	CreatedAt DATETIME DEFAULT GETDATE() NOT NULL,
	UpdatedAt DATETIME DEFAULT GETDATE() NOT NULL
	CONSTRAINT FKDoctor_Specialty
		FOREIGN KEY(SpecialtyID) REFERENCES Specialties(SpecialtyID) ON DELETE SET NULL
);

GO
CREATE TABLE DoctorSchedule(
    ScheduleID INT IDENTITY(1,1) PRIMARY KEY,
    DoctorID INT NOT NULL,
    DayOfWeek VARCHAR(10) NOT NULL CHECK (DayOfWeek IN ('Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday', 'Sunday')),
    StartTime TIME NOT NULL,
    EndTime TIME NOT NULL,
    SlotDuration INT NOT NULL,
    MaxPatientsPerSlot INT NOT NULL,
	CreatedAt DATETIME DEFAULT GETDATE() NOT NULL,
	UpdatedAt DATETIME DEFAULT GETDATE() NOT NULL,
    FOREIGN KEY(DoctorID) REFERENCES Doctors(DoctorID) ON DELETE CASCADE
);

GO
CREATE TABLE Appointments(
	AppointmentID INT IDENTITY(1,1) PRIMARY KEY,
	PatientID INT NOT NULL,
	DoctorID INT NOT NULL,
	AppointmentDate DATE NOT NULL,
	AppointmentTime TIME NOT NULL,
	AppointmentStatus VARCHAR(20) NOT NULL DEFAULT 'SCHEDULED' CHECK (AppointmentStatus IN ('SCHEDULED', 'COMPLETED', 'CANCELLED')),
	CONSTRAINT FKAppointment_Patient
		FOREIGN KEY(PatientID) REFERENCES Patients(PatientID) ON DELETE CASCADE,
	CONSTRAINT FKAppointment_Doctor
	FOREIGN KEY(DoctorID) REFERENCES Doctors(DoctorID) ON DELETE NO ACTION
);

GO
CREATE TABLE AppointmentAudit(
	AAuditID INT IDENTITY(1,1) PRIMARY KEY,
	AppointmentID INT NOT NULL,
	Operation VARCHAR(50) NOT NULL CHECK (Operation IN ('INSERT', 'UPDATE')),
	Remark VARCHAR(100),
	ATimestamp DATETIME DEFAULT GETDATE(),
	CONSTRAINT FKAudit_Appointment
		FOREIGN KEY(AppointmentID) REFERENCES Appointments(AppointmentID) ON DELETE CASCADE
);

GO
CREATE TABLE Visits(
	VisitID INT IDENTITY(1,1) PRIMARY KEY,
	AppointmentID INT NOT NULL,
	PatientID INT NOT NULL,
	DoctorID INT NOT NULL,
	Notes VARCHAR(1000),
	Diagnosis VARCHAR(1000),
	VisitDate DATE NOT NULL DEFAULT CAST(GETDATE() AS DATE),
	VisitTime TIME NOT NULL DEFAULT CAST(GETDATE() AS TIME),
	CONSTRAINT FKVisit_PATIENT
		FOREIGN KEY(PatientID) REFERENCES Patients(PatientID) ON DELETE NO ACTION,
	CONSTRAINT FKVisit_Doctor
		FOREIGN KEY(DoctorID) REFERENCES Doctors(DoctorID) ON DELETE NO ACTION,
	CONSTRAINT FKVisit_Appointment
		FOREIGN KEY(AppointmentID) REFERENCES Appointments(AppointmentID) ON DELETE NO ACTION
);

GO
CREATE TABLE Prescriptions(
	PrescriptionID INT IDENTITY(1,1) PRIMARY KEY,
	VisitID INT NOT NULL,
	PrescriptionDate DATE NOT NULL DEFAULT CAST(GETDATE() AS DATE),
	CONSTRAINT FKPrescription_Visit
		FOREIGN KEY(VisitID) REFERENCES Visits(VisitID) ON DELETE CASCADE
);

GO
CREATE TABLE PrescribedMedicines(
	PrescriptionID INT NOT NULL,
	MedicineName VARCHAR(50) NOT NULL,
	Dosage VARCHAR(50) NOT NULL,
	Duration VARCHAR(50) NOT NULL,
	CONSTRAINT FKMeds_Presc
		FOREIGN KEY(PrescriptionID) REFERENCES Prescriptions(PrescriptionID) ON DELETE CASCADE
);

GO
CREATE TABLE Bills(
	BillID INT IDENTITY(1,1) PRIMARY KEY,
	PatientID INT NOT NULL,
	VisitID INT NOT NULL,
	BillDate DATE NOT NULL DEFAULT CAST(GETDATE() AS DATE),
	BillTime TIME NOT NULL DEFAULT CAST(GETDATE() AS TIME),
	DoctorFee DECIMAL(10,2) NOT NULL,
	AdditionalFee DECIMAL(10,2) DEFAULT 0,
	DiscountAmount DECIMAL(10,2) DEFAULT 0,
	TotalBill DECIMAL(10,2) NOT NULL,
	PaymentStatus VARCHAR(10) NOT NULL DEFAULT 'UNPAID' CHECK (PaymentStatus IN ('PAID','UNPAID')),
	CONSTRAINT FKBill_Visit
		FOREIGN KEY(VisitID) REFERENCES Visits(VisitID) ON DELETE NO ACTION,
	CONSTRAINT FKBill_Patient
		FOREIGN KEY(PatientID) REFERENCES Patients(PatientID) ON DELETE NO ACTION
);

GO
CREATE TABLE Payments(
	PaymentID INT IDENTITY(1,1) PRIMARY KEY,
	BillID INT NOT NULL,
	AmountPaid DECIMAL(10,2) NOT NULL,
	PaymentMode VARCHAR(20) NOT NULL DEFAULT 'CASH' CHECK (PaymentMode IN ('CASH', 'CARD', 'UPI')),
	PaymentDate DATE NOT NULL DEFAULT CAST(GETDATE() AS DATE),
	PaymentTime TIME NOT NULL DEFAULT CAST(GETDATE() AS TIME),
	CONSTRAINT FKPayment_Bill
		FOREIGN KEY(BillID) REFERENCES Bills(BillID) ON DELETE CASCADE
);

GO
CREATE TABLE Administrations(
	AdminID INT IDENTITY(1,1) PRIMARY KEY,
	AdminName VARCHAR(50) NOT NULL,
	Phone VARCHAR(10) UNIQUE NOT NULL,
	Password VARCHAR(20) NOT NULL DEFAULT 'AdminPass',
	CreatedAt DATETIME DEFAULT GETDATE() NOT NULL,
	UpdatedAt DATETIME DEFAULT GETDATE() NOT NULL
);

GO
CREATE TABLE Receptionists(
	ReceptionistID INT IDENTITY(1,1) PRIMARY KEY,
	ReceptionistName VARCHAR(50) NOT NULL,
	Phone VARCHAR(10) UNIQUE NOT NULL,
	Password VARCHAR(20) NOT NULL DEFAULT 'RecPass',
	CreatedAt DATETIME DEFAULT GETDATE() NOT NULL,
	UpdatedAt DATETIME DEFAULT GETDATE() NOT NULL
);

GO
CREATE TABLE AuditLog(
	AuditLogID INT IDENTITY(1,1) PRIMARY KEY,
	RecordID INT,
	TableName VARCHAR(50) NOT NULL,
	Operation VARCHAR(20) NOT NULL CHECK (Operation IN ('INSERT', 'UPDATE', 'DELETE')),
	OldValue VARCHAR(MAX),
	NewValue VARCHAR(MAX),
	CreatedAt DATETIME NOT NULL DEFAULT GETDATE()
);


--------------------------------------------------------------------------------------------------------------------------

-- Register New Admin
GO
CREATE PROCEDURE RegisterAdmin
	@Name VARCHAR(50),
	@Phone VARCHAR(10)
AS
BEGIN
	BEGIN TRANSACTION;

	BEGIN TRY
		IF NOT EXISTS (SELECT 1 FROM Administrations WHERE Phone = @Phone)
			INSERT INTO Administrations(AdminName,Phone) VALUES (@Name,@Phone);
		ELSE 
			PRINT 'Admin Already Exists';
		COMMIT TRANSACTION;
	END TRY

	BEGIN CATCH
		ROLLBACK TRANSACTION;
		PRINT 'ERROR WHILE Registering New Admin';
	END CATCH;
END;

-- Trigger For Register New Admin
GO
CREATE TRIGGER LogNewAdmin
ON Administrations
AFTER INSERT 
AS
BEGIN
	BEGIN TRANSACTION
	BEGIN TRY
		INSERT INTO AuditLog(RecordID,TableName,Operation)
			SELECT AdminID, 'Administrations', 'INSERT'
		FROM INSERTED;
		COMMIT TRANSACTION;
	END TRY

	BEGIN CATCH
		ROLLBACK TRANSACTION;
	END CATCH
END;


-- Register New Receptionist
GO
CREATE PROCEDURE RegisterReceptionist 
	@Name VARCHAR(50),
	@Phone VARCHAR(10)
AS
BEGIN
	BEGIN TRANSACTION;

	BEGIN TRY
		IF NOT EXISTS (SELECT 1 FROM Receptionists WHERE Phone = @Phone)
			INSERT INTO Receptionists(ReceptionistName,Phone) VALUES (@Name,@Phone);
		ELSE 
			PRINT 'Receptionist Already Exists';
		COMMIT TRANSACTION;
	END TRY

	BEGIN CATCH
		ROLLBACK TRANSACTION;
		PRINT 'ERROR WHILE Registering New Receptionist';
	END CATCH;
END;

-- Trigger For Register New Receptionist
GO
CREATE TRIGGER LogNewReceptionist
ON Receptionists
AFTER INSERT
AS
BEGIN
	BEGIN TRANSACTION;
	BEGIN TRY
		INSERT INTO AuditLog(RecordID,TableName,Operation)
			SELECT ReceptionistID, 'Receptionists', 'INSERT'
		FROM INSERTED;
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION;
	END CATCH;
END;

------------------------------------ DOCTOR -----------------------------------------------------

-- Assigning/Updating Doctor's Specility
GO
CREATE PROCEDURE SetDoctorSpecility 
	@DoctorID INT, 
	@SpecialtyName VARCHAR(50)
AS
BEGIN
		BEGIN TRANSACTION
		BEGIN TRY

			IF @DoctorID IS NULL AND @SpecialtyName IS NULL
			BEGIN
				PRINT 'Please Provide DoctorId AND SpecialtyName'
				ROLLBACK TRANSACTION;
				RETURN;
			END;

			DECLARE @SpecialtyID INT;
			EXEC GetSpecialtyIDByName @SpecialtyName, @SpecialtyID OUTPUT;

			IF @SpecialtyID IS NULL
			BEGIN
				PRINT 'Specialty Not Exists Yet';
				ROLLBACK TRANSACTION;
				RETURN;
			END;

			UPDATE Doctors SET SpecialtyID = @SpecialtyID WHERE DoctorID = @DoctorID;
			PRINT 'Doctor Specility Successfully Assigned/Updated'
			COMMIT TRANSACTION;

		END TRY

		BEGIN CATCH
			ROLLBACK TRANSACTION;
			PRINT 'Error While Assigning Doctor Specility'
		END CATCH;
END;


-- Register New Doctor
GO
CREATE PROCEDURE RegisterDoctor
	@Name VARCHAR(50),
	@SpecialtyName VARCHAR(50), 
	@Phone VARCHAR(10),
	@Fee DECIMAL(10,2)
AS
BEGIN

	IF EXISTS (SELECT 1 FROM Doctors WHERE Phone = @Phone)
	BEGIN
		PRINT 'Doctors Phone Already Exists';
		RETURN;
	END;
	DECLARE @DoctorID INT;
	INSERT INTO Doctors(DoctorName,Phone,ConsultationFee) VALUES (@Name,@Phone,@Fee);
	SET @DoctorID = SCOPE_IDENTITY();
	EXEC SetDoctorSpecility @DoctorID,@SpecialtyName;
	PRINT 'New Doctor Is Registered';

END;


-- Trigger For register new doctor
GO
CREATE TRIGGER LogNewDoctor
ON Doctors
AFTER INSERT 
AS
BEGIN
	INSERT INTO AuditLog(RecordID,TableName,Operation)
		SELECT DoctorID, 'Doctors', 'INSERT'
    FROM INSERTED;
END;

-- set doctor schedule
GO
CREATE PROCEDURE AddDoctorSchedule
    @DoctorID INT,
    @DayOfWeek VARCHAR(10),
    @StartTime TIME,
    @EndTime TIME,
    @SlotDuration INT,
    @MaxPatientsPerSlot INT
AS
BEGIN
    -- Check Doctor Exists & Is Active
    IF NOT EXISTS (SELECT 1 FROM Doctors WHERE DoctorID = @DoctorID AND IsActive = 1)
    BEGIN
        PRINT 'Doctor Not Found or Inactive';
        RETURN;
    END;

    -- Validate Time Range
    IF (@StartTime >= @EndTime)
    BEGIN
        PRINT 'Invalid Time Range';
        RETURN;
    END;

    INSERT INTO DoctorSchedule
        (DoctorID, DayOfWeek, StartTime, EndTime, SlotDuration, MaxPatientsPerSlot)
    VALUES
        (@DoctorID, @DayOfWeek, @StartTime, @EndTime, @SlotDuration, @MaxPatientsPerSlot);

    PRINT 'Doctor Schedule Added Successfully';
END;



-- View Doctors by Specialty
GO
CREATE PROCEDURE ViewDoctorsBySpecialty @SpecialtyName VARCHAR(50)
AS
BEGIN
	SELECT d.DoctorID,d.DoctorName,s.SpecialtyName,ds.StartTime,ds.EndTime
	FROM Doctors AS d
	INNER JOIN Specialties AS s ON d.SpecialtyID = s.SpecialtyID
	INNER JOIN DoctorSchedule AS ds ON d.DoctorID = ds.DoctorID
	WHERE s.SpecialtyName = @SpecialtyName;
END;

-- Deactivate Doctor Profile
GO
CREATE PROCEDURE DeactivateDoctorProfile 
	@DoctorID INT
AS
BEGIN
	IF NOT EXISTS(SELECT 1 FROM Doctors AS d
				  INNER JOIN Appointments AS a ON d.DoctorID = a.DoctorID
				  WHERE a.AppointmentStatus = 'SCHEDULED'
				  AND d.DoctorID = @DoctorID)
		UPDATE Doctors SET IsActive = 0 WHERE DoctorID = @DoctorID;
END;

-- Trigger For Updating Doctor
GO
CREATE TRIGGER LogUpdateDoctor
ON Doctors
AFTER UPDATE
AS
BEGIN
	INSERT INTO AuditLog(RecordID,TableName,Operation,OldValue,NewValue)
	SELECT d.DoctorID,'Doctors','UPDATE',
	CONCAT('SpecialtyID: ' , d.SpecialtyID, 'IsActive: ', d.IsActive),
	CONCAT('SpecialtyID: ' , i.SpecialtyID, 'IsActive: ', i.IsActive)
	FROM INSERTED AS i
	INNER JOIN DELETED AS d ON d.DoctorID = i.DoctorID;
END;



------------------------------------ PATIENT -----------------------------------------------------

-- Register New Patient
GO
CREATE PROCEDURE RegisterPatient 
	@Name VARCHAR(50), 
	@DOB DATE, 
	@Phone VARCHAR(10), 
	@Address VARCHAR(100), 
	@BloodGroup VARCHAR(5)
AS
BEGIN
	BEGIN TRANSACTION;
	BEGIN TRY
		IF NOT EXISTS (SELECT 1 FROM Patients WHERE Phone = @Phone)
			INSERT INTO Patients(PatientName,DOB,Phone,Address,BloodGroup) VALUES
				(@Name,@DOB,@Phone,@Address,@BloodGroup);
		ELSE
			PRINT 'PATIENT ALREADY EXISTS';
		COMMIT TRANSACTION;
	END TRY

	BEGIN CATCH
		ROLLBACK TRANSACTION;
		PRINT 'ERROR While Registring New Patient';
	END CATCH;
END;

-- Trigger for Register New Patient
GO
CREATE TRIGGER LogNewPatient
ON Patients
AFTER INSERT 
AS
BEGIN
	INSERT INTO AuditLog(RecordID,TableName,Operation)
		SELECT PatientID, 'Patients', 'INSERT'
    FROM INSERTED;
END;

-- Get PatientID By Phone
GO
CREATE PROCEDURE GetPatientIDByPhone 
	@Phone VARCHAR(10),
	@PatientID INT OUTPUT
AS
BEGIN
	SELECT @PatientID = PatientID FROM Patients WHERE Phone = @Phone;
END;

-- Update Patient Info By ID Or Phone
GO
CREATE PROCEDURE UpdatePatientInfo 
	@PatientID INT = NULL,
	@Phone VARCHAR(10) = NULL,
	@Name VARCHAR(50),
	@NewPhone VARCHAR(10) = NULL,
	@DOB DATE ,
	@Address VARCHAR(100),
	@BloodGroup VARCHAR(5) 
AS
BEGIN
	BEGIN TRANSACTION;
	BEGIN TRY

		IF @PatientID IS NULL AND @Phone IS NULL	-- if patientID and Phone both null
			BEGIN
				PRINT 'Provide Either PatientID OR Phone';
				ROLLBACK TRANSACTION;
				RETURN;
			END;

		IF @PatientID IS NULL	-- getting patientID By Phone
				EXEC GetPatientIDByPhone @Phone, @PatientID OUTPUT

		IF @PatientID IS NULL	-- If PatientID not found
		 BEGIN
			ROLLBACK TRANSACTION;
			PRINT 'Patient Not Found';
			RETURN;
		END;

		IF @NewPhone IS NOT NULL AND EXISTS (SELECT 1 FROM Patients WHERE Phone = @NewPhone AND PatientID!=@PatientID)	-- if newPhone Already exists
			BEGIN
				ROLLBACK TRANSACTION;
				PRINT 'New Phone Already Exists';
				RETURN;
			END;

		UPDATE Patients SET PatientName=@Name,DOB=@DOB,Phone=ISNULL(@NewPhone, Phone),Address=@Address,BloodGroup=@BloodGroup WHERE PatientID = @PatientID;
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION;
		PRINT 'ERROR While Updating Patient Info';
	END CATCH

END;

-- Trigger for log update patient
GO
CREATE TRIGGER LogUpdatePatient
ON Patients
AFTER UPDATE
AS
BEGIN
	BEGIN TRANSACTION;
	BEGIN TRY
		INSERT INTO AuditLog(RecordID,TableName,Operation,OldValue,NewValue)
			SELECT
			d.PatientID,
			'Patients',
			'UPDATE',
			CONCAT('Name:', d.PatientName, ', Phone:', d.Phone, ', DOB:', d.DOB, ', Address:', d.Address, ', Blood:', d.BloodGroup),
			CONCAT('Name:', i.PatientName, ', Phone:', i.Phone, ', DOB:', i.DOB, ', Address:', i.Address, ', Blood:', i.BloodGroup)
		FROM inserted i
		INNER JOIN deleted d ON i.PatientID = d.PatientID;
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION;
	END CATCH;
END;


-- Search Patient Records
GO
CREATE PROCEDURE SearchPatientRecord
	@PatientID INT = NULL,
	@Phone VARCHAR(10)=NULL,
	@Name VARCHAR(50)=NULL
AS
BEGIN
	IF @PatientID IS NULL AND @Phone IS NULL AND @Name IS NULL
	BEGIN
		PRINT 'Provide Patient ID Or Phone Or Name';
		RETURN;
	END;

	IF @PatientID IS NOT NULL AND EXISTS (SELECT 1 FROM Patients WHERE PatientID = @PatientID)
		SELECT * FROM Patients WHERE PatientID = @PatientID;
	ELSE IF @Phone IS NOT NULL AND EXISTS (SELECT 1 FROM Patients WHERE Phone = @Phone)
		SELECT * FROM Patients WHERE Phone = @Phone;
	ELSE IF EXISTS (SELECT 1 FROM Patients WHERE PatientName LIKE '%'+@Name+'%')
		SELECT * FROM Patients WHERE PatientName LIKE '%'+@Name+'%';
	ELSE 
		PRINT 'No Patient Found Of this Record';
END


-- View Patient Visit History
GO
CREATE PROCEDURE ViewPatientHistory
	@PatientID INT
AS
BEGIN
	IF NOT EXISTS (SELECT 1 FROM Patients WHERE PatientID = @PatientID)
	BEGIN
		PRINT 'Patient Not Found'
		RETURN;
	END

	SELECT p.PatientID,p.PatientName,d.DoctorID,d.DoctorName,a.AppointmentID,v.VisitID,v.Diagnosis
	FROM Patients AS p
	INNER JOIN Appointments AS a ON p.PatientID = a.PatientID
	INNER JOIN Visits AS v ON v.AppointmentID = a.AppointmentID
	INNER JOIN Doctors AS d ON d.DoctorID = v.DoctorID
	WHERE p.PatientID = @PatientID
	ORDER BY v.VisitDate , v.VisitTime
END;


	
------------------------------------ Appointment -----------------------------------------------------

-- Book New Appointment
GO
CREATE PROCEDURE BookAppointment @PatientID INT, @DoctorID INT,@Time TIME,@Date DATE
AS
BEGIN
	IF NOT EXISTS( SELECT 1 FROM Appointments WHERE DoctorID=@DoctorID AND AppointmentStatus='SCHEDULED' AND AppointmentTime = @Time AND AppointmentDate = @Date)
		INSERT INTO Appointments(PatientID,DoctorID,AppointmentTime,AppointmentDate)
			VALUES (@PatientID,@DoctorID,@Time,@Date);
	ELSE 
		PRINT 'SLOT IS FULL';
END;

-- Trigger for Log New Appointment
GO
CREATE TRIGGER LogNewAppointment
ON Appointments
AFTER INSERT
AS
BEGIN
	INSERT INTO AuditLog(RecordID,TableName,Operation)
		SELECT AppointmentID,'Appointments','INSERT'
		FROM INSERTED;
END;


-- CHECK DOCTOR AVAILABILITY
GO
CREATE PROCEDURE CheckDoctorAvailability 
	@DoctorID INT, 
	@Date DATE
AS
BEGIN
	DECLARE @Day VARCHAR(10) = DATENAME(WEEKDAY, @Date);

	SELECT d.DoctorID, d.DoctorName,ds.StartTime,ds.EndTime,ds.MaxPatientsPerSlot,COUNT(a.AppointmentID) AS Booked,ds.MaxPatientsPerSlot - COUNT(a.AppointmentID) AS Available
	FROM DoctorSchedule ds
	INNER JOIN Doctors d ON d.DoctorID = ds.DoctorID
	LEFT JOIN Appointments a 
		ON a.DoctorID = ds.DoctorID
		AND a.AppointmentDate = @Date
		AND a.AppointmentTime >= ds.StartTime
		AND a.AppointmentTime < ds.EndTime
	WHERE ds.DoctorID = @DoctorID
	AND ds.DayOfWeek = @Day
	GROUP BY d.DoctorID,d.DoctorName,ds.StartTime,ds.EndTime,ds.MaxPatientsPerSlot;
END;


-- Cancel Appointment
GO
CREATE PROCEDURE CancelAppointment @AppointmentID INT
AS
BEGIN
	UPDATE Appointments SET AppointmentStatus = 'CANCELLED' WHERE AppointmentID = @AppointmentID;
END;

-- trigger for Audit Cancelled Appintment
GO
CREATE TRIGGER AuditAppointmentCancellation
ON Appointments
AFTER UPDATE
AS
BEGIN
	INSERT INTO AppointmentAudit(AppointmentID,Operation,Remark)
	SELECT i.AppointmentID, 'UPDATE','Appointment Cancelled'
	FROM INSERTED i
	INNER JOIN DELETED AS d ON i.AppointmentID = d.AppointmentID
	WHERE d.AppointmentStatus != 'CANCELLED' AND i.AppointmentStatus = 'CANCELLED';
END;

-- Reschedule Appointment
GO
CREATE PROCEDURE RescheduleAppointment @AppointmentID INT, @Time TIME, @Date DATE, @DoctorID INT
AS
BEGIN
	IF EXISTS( SELECT d.DoctorName,ds.StartTime,ds.EndTime
				FROM Doctors AS d
				INNER JOIN DoctorSchedule AS ds ON d.DoctorID = ds.DoctorID
				WHERE d.DoctorID = @DoctorID AND d.IsActive=1 AND ds.StartTime<=@Time AND ds.EndTime >= @Time)
		UPDATE Appointments SET AppointmentTime = @Time,AppointmentDate = @Date, DoctorID = @DoctorID
			WHERE AppointmentID = @AppointmentID;
END;

-- trigger for Audit Rescheuled Appintment
GO
CREATE TRIGGER AuditAppointmentReschedule
ON Appointments
AFTER UPDATE
AS
BEGIN
	INSERT INTO AppointmentAudit(AppointmentID,Operation,Remark)
	SELECT i.AppointmentID, 'UPDATE','Appointment Rescheduled'
	FROM INSERTED AS i
	INNER JOIN DELETED AS d ON i.AppointmentID = d.AppointmentID
	WHERE 
		i.AppointmentDate <> d.AppointmentDate
		OR i.AppointmentTime <> d.AppointmentTime
		OR i.DoctorID <> d.DoctorID;
END;

-- View Daily Appointment Schedule
GO
CREATE PROCEDURE ViewDailyAppointmentSchedule @Date DATE = NULL
AS
BEGIN
	IF @Date IS NULL
		SET @Date = GETDATE();
	SELECT d.DoctorName, p.PatientName, a.AppointmentTime FROM Appointments AS a 
	INNER JOIN Doctors AS d ON d.DoctorID = a.DoctorID
	INNER JOIN Patients AS p ON p.PatientID = a.PatientID
	WHERE AppointmentDate = @Date AND a.AppointmentStatus = 'SCHEDULED'
	ORDER BY a.AppointmentTime;
END;


------------------------------------ Visit,Prescription, -----------------------------------------------------

-- Record Patient Visit
GO
CREATE PROCEDURE RecordPatientVisit @AppointmentID INT,@Notes VARCHAR(1000),@Diagnosis VARCHAR(1000)
AS
BEGIN
	IF EXISTS ( SELECT 1 FROM Appointments WHERE AppointmentID = @AppointmentID)
	BEGIN
		DECLARE @PatientID INT, @DoctorID INT, @VisitTime TIME , @VisitDate DATE;
		SELECT @PatientID=PatientID,@DoctorID=DoctorID FROM Appointments WHERE AppointmentID = @AppointmentID;
		INSERT INTO Visits(AppointmentID,PatientID,DoctorID,Notes,Diagnosis) VALUES
			(@AppointmentID,@PatientID,@DoctorID,@Notes,@Diagnosis);
		UPDATE Appointments SET AppointmentStatus = 'COMPLETED' WHERE AppointmentID = @AppointmentID;
	END;
	ELSE 
		PRINT 'Appointment Not Found';
END;

-- trigger for log patient visit
GO
CREATE TRIGGER LogPatientNewVisit
ON Visits
AFTER INSERT
AS
BEGIN
	INSERT INTO AuditLog(RecordID,TableName,Operation)
	SELECT VisitID,'Visits','INSERT'
	FROM INSERTED;
END;


-- View Patient Medical History
GO
CREATE PROCEDURE ViewPatientMedicalHistory @PatientID INT
AS
BEGIN
	IF EXISTS(SELECT 1 FROM Visits WHERE PatientID = @PatientID)
	BEGIN
		SELECT * FROM Visits AS v
		INNER JOIN Appointments AS a ON a.AppointmentID = v.AppointmentID
		INNER JOIN Prescriptions as pr ON v.VisitID = pr.VisitID
		INNER JOIN Patients as p ON v.PatientID = p.PatientID
		INNER JOIN Doctors as d ON v.DoctorID = d.DoctorID
		WHERE v.PatientID = @PatientID
		ORDER BY v.VisitDate DESC;
	END;
END;


-- Create New Prescription
GO
CREATE PROCEDURE CreatePrescription @VisitID INT
AS
BEGIN
	IF EXISTS (SELECT 1 FROM Visits WHERE VisitID = @VisitID)
	BEGIN
		INSERT INTO Prescriptions(VisitID)
		VALUES (@VisitID)
	END;
END;

-- trigger for new prescription
GO
CREATE TRIGGER LogPrescription
ON Prescriptions
AFTER INSERT
AS
BEGIN
	INSERT INTO AuditLog(RecordID,TableName,Operation)
	SELECT PrescriptionID,'Prescriptions','INSERT'
	FROM INSERTED
END;


-- Add Medicine
GO
CREATE PROCEDURE AddMedicine @PrescriptionID INT,@MedicineName VARCHAR(50),@Dosage VARCHAR(50),@Duration VARCHAR(50)
AS
BEGIN
	IF EXISTS (SELECT 1 FROM Prescriptions WHERE PrescriptionID = @PrescriptionID)
	BEGIN
		INSERT INTO PrescribedMedicines(PrescriptionID,MedicineName,Dosage,Duration)
		VALUES (@PrescriptionID,@MedicineName,@Dosage,@Duration)
	END;

END;


--------------------------- Bills, Payment -----------------------------------------
-- Generate Bill
GO
CREATE PROCEDURE GenerateBill @VisitID INT,@AdditionalCharges DECIMAL(10,2) = 0.0, @DiscountAmount DECIMAL(10,2) = 0.0
AS
BEGIN
	IF EXISTS (SELECT 1 FROM Visits WHERE VisitID = @VisitID)
	BEGIN
		DECLARE @TotalBill DECIMAL (10,2);
		DECLARE @DoctorFee DECIMAL (10,2);
		DECLARE @PatientID INT

		SELECT @DoctorFee = d.ConsultationFee FROM Doctors AS d
		INNER JOIN Visits AS v ON v.DoctorID = d.DoctorID
		WHERE VisitID = @VisitID;

		SELECT @PatientID = PatientID FROM Visits
		WHERE VisitID = @VisitID;

		SET @TotalBill = @AdditionalCharges + @DoctorFee - @DiscountAmount;

		INSERT INTO Bills(VisitID,PatientID,DoctorFee,AdditionalFee,DiscountAmount,TotalBill)
			VALUES (@VisitID,@PatientID,@DoctorFee,@AdditionalCharges,@DiscountAmount,@TotalBill);
	END;
END;

-- Record Payment
GO
CREATE PROCEDURE RecordPayment @BillID INT,@Amount DECIMAL(10,2), @PaymentMode VARCHAR(10) = 'CASH'
AS
BEGIN
	IF EXISTS(SELECT 1 FROM Bills WHERE BillID = @BillID)
	BEGIN
		INSERT INTO Payments(BillID,AmountPaid,PaymentMode)
			VALUES (@BillID,@Amount,@PaymentMode)
	END;
END;

-- Bill Payment
GO
CREATE PROCEDURE PayBill @BillID INT,@Amount DECIMAL(10,2),@PaymentMode VARCHAR(10) = 'CASH'
AS
BEGIN
	IF EXISTS(SELECT 1 FROM Bills WHERE BillID = @BillID)
	BEGIN 
		IF EXISTS (SELECT 1 FROM Bills WHERE BillID = @BillID AND TotalBill = @Amount)
		BEGIN
			UPDATE Bills SET PaymentStatus = 'PAID' WHERE BillID = @BillID;
			EXEC RecordPayment @BillID,@Amount,@PaymentMode;
		END;
	END;
END;


-- View Outstanding(UNPAID) Bills
GO
CREATE PROCEDURE ViewOutstandingBills 
AS
BEGIN
	SELECT v.PatientID,p.PatientName,b.* FROM Bills AS b
	INNER JOIN Visits AS v ON b.VisitID = v.VisitID
	INNER JOIN Patients AS p ON p.PatientID = v.PatientID
	WHERE b.PaymentStatus = 'UNPAID'
END;

-- Generate Revenue Report
GO
CREATE PROCEDURE GenerateRevenueReport
    @StartDate DATE,
    @EndDate DATE,
    @MinRevenue DECIMAL(10,2) = 0
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        CAST(b.BillDate AS DATE) AS RevenueDate,
        d.DoctorName,
        s.SpecialtyName,
        SUM(b.TotalBill) AS TotalRevenue
    FROM Bills b
    INNER JOIN Visits v ON b.VisitID = v.VisitID
    INNER JOIN Appointments a ON v.AppointmentID = a.AppointmentID
    INNER JOIN Doctors d ON a.DoctorID = d.DoctorID
    INNER JOIN Specialties s ON d.SpecialtyID = s.SpecialtyID
    WHERE b.BillDate BETWEEN @StartDate AND @EndDate
    GROUP BY 
        CAST(b.BillDate AS DATE),
        d.DoctorName,
        s.SpecialtyName
    HAVING SUM(b.TotalBill) >= @MinRevenue
    ORDER BY RevenueDate, TotalRevenue DESC;
END;
GO


-------------------------------- Specialty -------------------------------

-- CREATE Specialty
GO
CREATE PROCEDURE AddNewSpecialty @SpecialtyName VARCHAR(50)
AS
BEGIN
	IF NOT EXISTS (SELECT 1 FROM Specialties WHERE SpecialtyName = @SpecialtyName)
		INSERT INTO Specialties(SpecialtyName) 
			VALUES (@SpecialtyName);
	ELSE 
		PRINT 'Specialty Already Exists';
END;

-- trigger for log new specialty
GO
CREATE TRIGGER LogNewSpecialty
ON Specialties
AFTER INSERT
AS
BEGIN
	INSERT INTO AuditLog(RecordID,TableName,Operation)
	SELECT SpecialtyID, 'Specialties', 'INSERT'
	FROM INSERTED;
END;


-- Get SpecialtyID By Name
GO
CREATE PROCEDURE GetSpecialtyIDByName @SpecialtyName VARCHAR(50), @SpecialtyID INT OUTPUT
AS
BEGIN
	SELECT @SpecialtyID = SpecialtyID FROM Specialties WHERE SpecialtyName = @SpecialtyName;
END;

-- Display Specialty By SpecialtyID
GO
CREATE PROCEDURE DisplaySpecialtyByID @SpecialtyID INT
AS
BEGIN
	SELECT * FROM Specialties WHERE SpecialtyID = @SpecialtyID;
END;

-- Display All Specilaty
GO
CREATE PROCEDURE DisplayAllSpecialty
AS
BEGIN
	SELECT * FROM Specialties;
END;

-- Update Specialty
GO
CREATE PROCEDURE UpdateSpecialty @SpecialtyID INT = NULL,@SpecialtyOldName VARCHAR(50) = NULL,@SpecialtyNewName VARCHAR(50)
AS
BEGIN
	IF @SpecialtyID IS NULL AND @SpecialtyOldName IS NULL
	BEGIN
		PRINT 'Please Provide SpecialtyID or Name'
		RETURN;
	END;

	IF @SpecialtyID IS NULL
		EXEC GetSpecialtyIDByName @SpecialtyOldName, @SpecialtyID OUTPUT;

	IF @SpecialtyID IS NULL OR NOT EXISTS (SELECT 1 FROM Specialties WHERE SpecialtyID = @SpecialtyID)
	BEGIN
		PRINT 'Specialty Not Found'
		RETURN;
	END

	UPDATE Specialties SET SpecialtyName = @SpecialtyNewName WHERE SpecialtyID = @SpecialtyID;
	PRINT 'Specialty Updated Successfully';

END;

-- trigger for log update specialty
GO
CREATE TRIGGER LogUpdateSpecialty
ON Specialties
AFTER UPDATE
AS
BEGIN
	INSERT INTO AuditLog(RecordID,TableName,Operation,OldValue,NewValue)
	SELECT 
		d.SpecialtyID,
		'Specialties',
		'UPDATE',
		CONCAT('SpecialtyName: ', d.SpecialtyName),
		CONCAT('SpecialtyName: ', i.SpecialtyName)
	FROM INSERTED i
	INNER JOIN DELETED d 
		ON i.SpecialtyID = d.SpecialtyID;
END;


-- Delete Specialty
GO
CREATE PROCEDURE DeleteSpecialty @SpecialtyID INT = NULL,@SpecialtyName VARCHAR(50) = NULL
AS 
BEGIN


	IF @SpecialtyID IS NULL AND @SpecialtyName IS NOT NULL	-- If Id not exists fetching the id
		EXEC GetSpecialtyIDByName @SpecialtyName, @SpecialtyID;

	IF @SpecialtyID IS NOT NULL	-- Delete By ID
	BEGIN
		IF EXISTS (SELECT 1 FROM Specialties WHERE SpecialtyID = @SpecialtyID)	
			BEGIN
				DECLARE @DoctorCount INT
				SELECT @DoctorCount = COUNT(d.DoctorID) FROM Specialties AS s
				INNER JOIN Doctors AS d ON d.SpecialtyID = s.SpecialtyID
				WHERE s.SpecialtyID = @SpecialtyID;
			
				IF(@DoctorCount=0)
				BEGIN
					DELETE FROM Specialties WHERE SpecialtyID = @SpecialtyID;
					PRINT 'SPECIALTY DELETED SUCCESSFULLY'
				END
				ELSE
					PRINT 'THIS SPECIALTY IS ASSIGNED TO ' + CAST(@DoctorCount AS VARCHAR) + 'DOCTORS';
			END;
		ELSE 
			PRINT 'SPECIALTY NOT EXISTS';
	END;
END;

-- trigger for log delete specialty
GO
CREATE TRIGGER LogDeleteSpecialty
ON Specialties
AFTER DELETE
AS
BEGIN
	INSERT INTO AuditLog(RecordID,TableName,Operation,OldValue,NewValue)
	SELECT 
		d.SpecialtyID,
		'Specialties',
		'DELETE',
		CONCAT('SpecialtyName: ', d.SpecialtyName),
		NULL
	FROM DELETED d;
END;

----------------------------- Audit Logs ----------------------------------------
GO
CREATE PROCEDURE ViewAuditLogs
AS
BEGIN
	SELECT * FROM AuditLog;
END;