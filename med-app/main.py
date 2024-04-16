import spacy
from flask import Flask, request, jsonify

app = Flask(__name__)

# Load spaCy English model
nlp = spacy.load("en_core_web_sm")

@app.route('/chat', methods=['POST'])
def chat():
    data = request.json
    message = data['message']

    # Diagnose based on user's input
    response = diagnose_condition(message)

    return jsonify({"response": response})

def diagnose_condition(input_text):
    # Process the input text using spaCy
    doc = nlp(input_text.lower())

    # Keywords related to sports injuries and medical conditions
    sports_conditions = {
        "injury": ["pain", "swelling", "bruising", "restricted movement"],
        "sprain": ["pain", "swelling", "limited range of motion"],
        "strain": ["pain", "muscle tightness", "limited flexibility"],
        "cramps": ["muscle spasms", "pain"],
        "fatigue": ["tiredness", "low energy", "poor performance", "tired"],
        "dehydration": ["thirst", "dry mouth", "dark urine", "faint"],
        "overtraining": ["fatigue", "decreased performance", "mood changes"]
    }

    medical_conditions = {
        "diabetes": ["frequent urination", "excessive thirst", "fatigue"],
        "asthma": ["shortness of breath", "wheezing", "chest tightness"],
        "heat exhaustion": ["heavy sweating", "rapid pulse", "dizziness", "sweat"],
        "anxiety": ["restlessness", "worry", "tense muscles"],
        "stress": ["headaches", "sleep problems", "cant sleep properly", "cant sleep", "irritability", "anger issues", "angry", "sleep"],
        "depression": ["persistent sadness", "loss of interest", "fatigue", "sad"],
        "insomnia": ["difficulty falling asleep", "waking up frequently", "daytime tiredness", "tired"]
    }

    # Sample prescriptions for each condition
    sports_prescriptions = {
        "injury": "Rest the injured area, apply ice for 15-20 minutes every 2-3 hours, and elevate the injured limb.",
        "sprain": "Use RICE (Rest, Ice, Compression, Elevation) method. Take over-the-counter pain relievers as needed.",
        "strain": "Rest the strained muscle, apply heat to relax the muscle, and gently stretch the muscle.",
        "cramps": "Massage the cramped muscle, stretch gently, and hydrate with electrolyte-rich fluids.",
        "fatigue": "Get adequate rest, hydrate well, and maintain a balanced diet rich in carbohydrates and proteins.",
        "dehydration": "Drink plenty of water and electrolyte-rich fluids. Avoid caffeine and alcohol.",
        "overtraining": "Take a break from training, get plenty of rest, and focus on recovery and relaxation."
    }

    medical_prescriptions = {
        "diabetes": "Monitor blood sugar levels regularly, maintain a balanced diet, exercise regularly, and take prescribed medications.",
        "asthma": "Use prescribed inhalers as directed, avoid triggers, and have an action plan for asthma attacks.",
        "heat exhaustion": "Move to a cooler place, rest, hydrate with cool fluids, and apply cool compresses.",
        "anxiety": "Practice relaxation techniques, exercise regularly, maintain a healthy diet, and consider therapy or counseling.",
        "stress": "Practice stress management techniques like meditation or deep breathing, exercise regularly, and maintain a balanced diet.",
        "depression": "Seek therapy or counseling, practice self-care, maintain a routine, and consider medication if prescribed by a doctor.",
        "insomnia": "Practice good sleep hygiene, establish a bedtime routine, limit screen time before bed, and consider relaxation techniques."
    }

    # Check for sports-related symptoms
    for condition, symptoms in sports_conditions.items():
        if any(symptom in input_text.lower() for symptom in symptoms):
            return f"You may have {condition}. Prescription: {sports_prescriptions.get(condition, 'Rest and consult a doctor for specific treatment.')}"

    # Check for medical symptoms
    for condition, symptoms in medical_conditions.items():
        if any(symptom in input_text.lower() for symptom in symptoms):
            return f"You may have {condition}. Prescription: {medical_prescriptions.get(condition, 'Consult a doctor for specific treatment.')}"

    # Default response
    return "I'm sorry, I don't understand. Please specify your symptoms or concerns related to athlete's health."





if __name__ == '__main__':
    app.run(debug=True)
