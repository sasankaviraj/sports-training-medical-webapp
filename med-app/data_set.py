dataset = [
    {
        "question": "How would you describe your current mood?",
        "diagnosis": {
            "name": "Depression",
            "keywords": ["depression", "sadness", "hopelessness", "low mood", "down", "melancholy", "despair", "despondency", "desolation", "gloom", "grief", "anguish", "desperation", "worthlessness", "apathy", "fatigue", "tearfulness", "anxiety", "loneliness", "emptiness", "isolation", "disinterest", "irritability", "lethargy", "restlessness", "guilt", "self-loathing", "self-harm", "suicidal thoughts", "numbness", "loss", "desperation", "unhappiness", "unmotivated", "unworthy", "dejected", "isolated", "exhausted", "tearful", "sleepless", "neglected", "worthless", "isolated", "unloved", "hopeless", "blue", "disheartened", "desperate", "downhearted"]
        },
        "prescription": "Consider cognitive-behavioral therapy (CBT), engage in regular exercise, maintain a healthy diet, ensure sufficient sleep, and consider medication if prescribed by a doctor."
    },
    {
        "question": "Have you experienced any significant changes in your appetite recently (increase or decrease)?",
        "diagnosis": {
            "name": "Eating Disorder",
            "keywords": ["eat", "appetite", "eating", "food", "hunger", "cravings", "weight", "nutrition", "binge", "purge", "restrict", "anorexia", "bulimia", "binge-eating", "emotional eating", "comfort eating", "body image", "dieting", "calories", "nutrients", "overeating", "undereating", "bingeing", "craving", "overeater", "undereater", "starvation", "fasting", "diet", "disorder", "body dysmorphia", "overeater", "undereater", "malnourished", "emotional eater", "craving", "famine", "starving", "restricting", "weight loss", "weight gain", "underweight", "overweight", "malnourished", "purging", "overeater", "undernourished", "unhealthy relationship with food", "food obsession", "binge-purge", "weight obsession", "eating pattern", "body dissatisfaction"]
        },
        "prescription": "Undergo psychotherapy focused on eating behaviors, establish regular eating patterns, keep a food diary, and consider medication if prescribed by a doctor."
    },
    {
        "question": "Are you experiencing feelings of sadness or hopelessness that persist over time?",
        "diagnosis": {
            "name": "Stress",
            "keywords": ["depression", "sadness", "hopelessness", "low mood", "down", "melancholy", "despair", "despondency", "desolation", "gloom", "grief", "anguish", "desperation", "worthlessness", "apathy", "fatigue", "tearfulness", "anxiety", "loneliness", "emptiness", "isolation", "disinterest", "irritability", "lethargy", "restlessness", "guilt", "self-loathing", "self-harm", "suicidal thoughts", "numbness", "loss", "desperation", "unhappiness", "unmotivated", "unworthy", "dejected", "isolated", "exhausted", "tearful", "sleepless", "neglected", "worthless", "isolated", "unloved", "hopeless", "blue", "disheartened", "desperate", "downhearted"]
        },
        "prescription": "Practice relaxation techniques such as deep breathing exercises, engage in enjoyable activities, maintain social connections, and consider medication if prescribed by a doctor."
    },
    {
        "question": "Have you experienced a loss of interest in activities that once brought you pleasure?",
        "diagnosis": {
            "name": "Depression",
            "keywords": ["depression", "loss of interest", "anhedonia", "low mood", "down", "melancholy", "despair", "despondency", "desolation", "gloom", "grief", "anguish", "desperation", "worthlessness", "apathy", "fatigue", "tearfulness", "anxiety", "loneliness", "emptiness", "isolation", "disinterest", "irritability", "lethargy", "restlessness", "guilt", "self-loathing", "self-harm", "suicidal thoughts", "numbness", "loss", "desperation", "unhappiness", "unmotivated", "unworthy", "dejected", "isolated", "exhausted", "tearful", "sleepless", "neglected", "worthless", "isolated", "unloved", "hopeless", "blue", "disheartened", "desperate", "downhearted"]
        },
        "prescription": "Engage in behavioral activation techniques, set achievable goals, seek social support, and consider medication if prescribed by a doctor."
    },
    {
        "question": "Have you noticed a change in your sleep patterns, such as difficulty falling asleep or waking up frequently during the night?",
        "diagnosis": {
            "name": "Insomnia",
            "keywords": ["insomnia", "sleep problems", "difficulty falling asleep", "frequent waking", "sleeplessness", "trouble sleeping", "restless sleep", "nightmares", "sleep deprivation", "awakening", "sleep disturbance", "sleep disorder", "trouble falling asleep", "poor sleep", "sleeplessness", "tiredness", "fatigue", "restlessness", "irritability", "exhaustion", "sleep cycle", "bedtime", "nighttime waking", "restless", "trouble staying asleep", "sleeplessness", "wakefulness", "restless leg syndrome", "sleep apnea", "snoring", "circadian rhythm disorder", "night sweats", "tossing and turning", "difficulty waking", "sleep onset", "delayed sleep phase syndrome", "shift work disorder", "sleep hygiene", "sleep deprivation", "excessive daytime sleepiness", "trouble sleeping through the night", "waking up too early", "difficulty sleeping", "sleep quality", "sleeping problems", "nighttime awakenings", "sleep maintenance", "early morning awakening"]
        },
        "prescription": "Implement relaxation techniques such as progressive muscle relaxation, establish a consistent sleep schedule, limit caffeine and screen time before bed, and consider medication if prescribed by a doctor."
    },
    {
        "question": "Are you experiencing physical symptoms such as headaches or stomachaches without a clear medical cause?",
        "diagnosis": {
            "name": "Stress",
            "keywords": ["stress", "headaches", "stomachaches", "physical symptoms", "tension", "stressful", "tense", "stressor", "anxiety", "stressful situation", "nervousness", "pressure", "strain", "tension headache", "stress-related", "muscle tension", "stressful event", "stress response", "stressful life", "stress-induced", "stressful day", "stressful job", "stress management", "stress level", "stress-related disorder", "stress relief", "stress reaction", "stressful time", "stress hormone", "stressful period", "stress symptoms", "stressful experience", "stressful situation", "stressful environment", "stressful situation", "stressful lifestyle", "stressful situation", "stress factor", "stressful moment", "stressful situation", "stressful situation", "stressful situation", "stressful situation", "stressful situation", "stressful situation", "stressful situation", "stressful situation"]
        },
        "prescription": "Practice stress reduction techniques such as mindfulness meditation, engage in regular physical activity, maintain a balanced diet, and consider medication if prescribed by a doctor."
    }
    # Add more entries for other questions
]

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
