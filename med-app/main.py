import spacy
from flask import Flask, request, jsonify

from chat import diagnose_condition
from data_set import dataset

app = Flask(__name__)

# Load spaCy English model
nlp = spacy.load("en_core_web_sm")


# Function to calculate similarity between two sets of keywords
def calculate_similarity(set1, set2):
    intersection = set1.intersection(set2)
    union = set1.union(set2)
    return len(intersection) / len(union) if union else 0


@app.route('/diagnose', methods=['POST'])
def diagnose():
    data = request.json
    responses = data['responses']

    diagnosis = ""
    prescription = ""

    # Analyze responses using NLP and match with dataset
    for response in responses:
        response_text = response["answer"].lower()
        response_keywords = set(token.text.lower() for token in nlp(response_text))
        condition_met = False
        for entry in dataset:
            # Check for "Yes" or "No" answers
            if isinstance(entry["diagnosis"], dict):
                if entry["question"] == response["question"]:
                    if "yes" in response_keywords:
                        diagnosis = entry["diagnosis"]["name"]
                        prescription = entry["prescription"]
                        condition_met = True
                        break
                    elif "no" in response_keywords:
                        break
                    # Check for detailed responses
                    for keyword in entry["diagnosis"]["keywords"]:
                        if keyword in response_keywords:
                            diagnosis = entry["diagnosis"]["name"]
                            prescription = entry["prescription"]
                            break
                    if diagnosis:
                        condition_met = True
                        break
        if condition_met:
            break

    if diagnosis and prescription:
        return jsonify({"diagnosis": diagnosis, "prescription": prescription})
    else:
        return jsonify({"error": "Diagnosis not found."})


@app.route('/chat', methods=['POST'])
def chat():
    data = request.json
    message = data['message']

    # Diagnose based on user's input
    response = diagnose_condition(message)

    return jsonify({"response": response})


if __name__ == '__main__':
    app.run(debug=True)
