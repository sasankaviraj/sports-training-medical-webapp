import spacy
from flask import request, jsonify
import data_set

# Load spaCy English model
nlp = spacy.load("en_core_web_sm")


def diagnose_condition(input_text):
    # Process the input text using spaCy
    doc = nlp(input_text.lower())

    # Check for sports-related symptoms
    for condition, symptoms in data_set.sports_conditions.items():
        if any(symptom in input_text.lower() for symptom in symptoms):
            return f"You may have {condition}. Prescription: {data_set.sports_prescriptions.get(condition, 'Rest and consult a doctor for specific treatment.')}"

    # Check for medical symptoms
    for condition, symptoms in data_set.medical_conditions.items():
        if any(symptom in input_text.lower() for symptom in symptoms):
            return f"You may have {condition}. Prescription: {data_set.medical_prescriptions.get(condition, 'Consult a doctor for specific treatment.')}"

    # Default response
    return "I'm sorry, I don't understand. Please specify your symptoms or concerns related to athlete's health."
