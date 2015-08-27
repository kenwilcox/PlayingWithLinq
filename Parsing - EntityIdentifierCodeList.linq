<Query Kind="Statements" />

// Parsing - https://www.emedny.org/epaces/help/Managing_Claims/Real_Time_Responses/Entity_Identifier_Code_List.htm

var dump = @"13

Contracted Service Provider

17

Consultant's Office

1E

Health Maintenance Organization (HMO)

1G

Oncology Center

1H

Kidney Dialysis Unit

1I

Preferred Provider Organization (PPO)

1O

Acute Care Hospital

1P

Provider

1Q

Military Facility

1R

University, College or School

1S

Outpatient Surgicenter

1T

Physician, Clinic or Group Practice

1U

Long Term Care Facility

1V

Extended Care Facility

1W

Psychiatric Health Facility

1X

Laboratory

1Y

Retail Pharmacy

1Z

Home Health Care

28

Subcontractor

2A

Federal, State, County or City Facility

2B

Third-Party Administrator

2D

Miscellaneous Health Care Facility

2E

Non-Health Care Miscellaneous Facility

2I

Church Operated Facility

2K

Partnership

2P

Public Health Service Facility

2Q

Veterans Administration Facility

2S

Public Health Service Indian Service Facility

2Z

Hospital Unit of an Institution (prison hospital, college infirmary, etc.)

30

Service Supplier

36

Employer

3A

Hospital Unit Within an Institution for the Mentally Retarded

3C

Tuberculosis and Other Respiratory Diseases Facility

3D

Obstetrics and Gynecology Facility

3E

Eye, Ear, Nose and Throat Facility

3F

Rehabilitation Facility

3G

Orthopedic Facility

3H

Chronic Disease Facility

3I

Other Specialty Facility

3J

Children's General Facility

3K

Children's Hospital Unit of an Institution

3L

Children's Psychiatric Facility

3M

Children's Tuberculosis and Other Respiratory Diseases Facility

3N

Children's Eye, Ear, Nose and Throat Facility

3O

Children's Rehabilitation Facility

3P

Children's Orthopedic Facility

3Q

Children's Chronic Disease Facility

3R

Children's Other Speciality Facility

3S

Institution for Mental Retardation

3T

Alcoholism and Other Chemical Dependency Facility

3U

General Inpatient Care the AIDS/ARC Facility

3V

AIDS/ARC Unit

3W

Specialized Outpatient Program for AIDS/ARC

3X

Alcohol/Drug Abuse or Dependency Inpatient Unit

3Y

Alcohol/Drug Abuse or Dependency Outpatient Services

3Z

Arthritis Treatment Center

40

Receiver

43

Claimant Authorized Representative

44

Data Processing Service Bureau

4A

Birthing Room/LDRP Room

4B

Burn Care Unit

4C

Cardiac Catheterization Laboratory

4D

Open-Heart Surgery Facility

4E

Cardiac Intensive Care Unit

4F

Angioplasty Facility

4G

Chronic Obstructive Pulmonary Disease Service Facility

4H

Emergency Department

4I

Trauma Center (Certified)

4J

Extracorporeal Shock-Wave Lithotripter (ESWL) Unit

4L

Genetic Counseling/Screening Services

4M

Adult Day Care Program Facility

4N

Alzheimer's Diagnostic/Assessment Services

4O

Comprehensive Geriatric Assessment Facility

4P

Emergency Response (Geriatric) Unit

4Q

Geriatric Acute Care Unit

4R

Geriatric Clinics

4S

Respite Care Facility

4U

Patient Education Unit

4V

Community Health Promotion Facility

4W

Worksite Health Promotion Facility

4X

Hemodialysis Facility

4Y

Home Health Services

4Z

Hospice

5A

Medical Surgical or Other Intensive Care Unit

5B

Histopathology Laboratory

5C

Blood Bank

5D

Neonatal Intensive Care Unit

5E

Obstetrics Unit

5F

Occupational Health Services

5G

Organized Outpatient Services

5H

Pediatric Acute Inpatient Unit

5I

Psychiatric Child/Adolescent Services

5J

Psychiatric Consultation-Liaison Services

5K

Psychiatric Education Services

5L

Psychiatric Emergency Services

5M

Psychiatric Geriatric Services

5N

Psychiatric Inpatient Unit

5O

Psychiatric Outpatient Services

5P

Psychiatric Partial Hospitalization Program

5Q

Megavoltage Radiation Therapy Unit

5R

Radioactive Implants Unit

5S

Therapeutic Radioisotope Facility

5T

X-Ray Radiation Therapy Unit

5U

CT Scanner Unit

5V

Diagnostic Radioisotope Facility

5W

Magnetic Resonance Imaging (MRI) Facility

5X

Ultrasound Unit

5Y

Rehabilitation Inpatient Unit

5Z

Rehabilitation Outpatient Services

61

Performed At

6A

Reproductive Health Services

6B

Skilled Nursing or Other Long-Term Care Unit

6C

Single Photon Emission Computerized Tomography (SPECT) Unit

6D

Organized Social Work Service Facility

6E

Outpatient Social Work Services

6F

Emergency Department Social Work Services

6G

Sports Medicine Clinic/Services

6H

Hospital Auxiliary Unit

6I

Patient Representative Services

6J

Volunteer Services Department

6K

Outpatient Surgery Services

6L

Organ/Tissue Transplantation Unit

6M

Orthopedic Surgery Facility

6N

Occupational Therapy Services

6O

Physical Therapy Services

6P

Recreational Therapy Services

6Q

Respiratory Therapy Services

6R

Speech Therapy Services

6S

Women's Health Center/Services

6U

Cardiac Rehabilitation Program Facility

6V

Non-Invasive Cardiac Assessment Services

6W

Emergency Medical Technician

6X

Disciplinary Contact

6Y

Case Manager

71

Attending Physician

72

Operating Physician

73

Other Physician

74

Corrected Insured

77

Service Location

7C

Place of Occurrence

80

Hospital

82

Rendering Provider

84

Subscriber's Employer

85

Billing Provider

87

Pay-to Provider

95

Research Institute

CK

Pharmacist

CZ

Admitting Surgeon

D2

Commercial Insurer

DD

Assistant Surgeon

DJ

Consulting Physician

DK

Ordering Physician

DN

Referring Provider

DO

Dependent Name

DQ

Supervising Physician

E1

Person or Other Entity Legally Responsible for a Child

E2

Person or Other Entity With Whom a Child Resides

E7

Previous Employer

E9

Participating Laboratory

FA

Facility

FD

Physical Address

FE

Mail Address

G0

Dependent Insured

G3

Clinic

GB

Other Insured

GD

Guardian

GI

Paramedic

GJ

Paramedical Company

GK

Previous Insured

GM

Spouse Insured

GY

Treatment Facility

HF

Healthcare Professional Shortage Area (HPSA) Facility

HH

Home Health Agency

I3

Independent Physicians Association (IPA)

IJ

Injection Point

IL

Insured or Subscriber

IN

Insurer

LI

Independent Lab

LR

Legal Representative

MR

Medical Insurance Carrier

OB

Ordered By

OD

Doctor of Optometry

OX

Oxygen Therapy Facility

P0

Patient Facility

P2

Primary Insured or Subscriber

P3

Primary Care Provider

P4

Prior Insurance Carrier

P6

Third Party Reviewing Preferred Provider Organization (PPO)

P7

Third Party Repricing Preferred Provider Organization (PPO)

PT

Party to Receive Test Report

PV

Party performing certification

PW

Pick up Address

QA

Pharmacy

QB

Purchase Service Provider

QC

Patient

QD

Responsible Party

QE

Policyholder

QH

Physician

QK

Managed Care

QL

Chiropractor

QN

Dentist

QO

Doctor of Osteopathy

QS

Podiatrist

QV

Group Practice

QY

Medical Doctor

RC

Receiving Location

RW

Rural Health Clinic

S4

Skilled Nursing Facility

SJ

Service Provider

SU

Supplier/Manufacturer

T4

Transfer Point - Used to identify the geographic location where a patient is transferred or diverted

TQ

Third Party Reviewing Organization (TPO)

TT

Transfer To

TU

Third Party Repricing Organization (TPO)

UH

Nursing Home

X3

Utilization Management Organization

X4

Spouse

X5

Durable Medical Equipment Supplier

ZZ

Mutually Defined";

var crap = dump.Split(new char[] {'\n', '\r'}, StringSplitOptions.RemoveEmptyEntries);
//crap.Dump();

string rubyHash = "\"{0}\" => \"{1}\",";
string hash = "";
for(var i = 0; i < crap.Length; i+=2) {
  hash += string.Format(rubyHash, crap[i], crap[i+1]) ;
}

string realDeal = "rename_me = {" + hash + "}";
realDeal.Dump();