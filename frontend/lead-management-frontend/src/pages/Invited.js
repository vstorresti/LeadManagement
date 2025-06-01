import React, { useEffect, useState } from 'react';
import api from '../services/api';
import LeadCard from '../components/LeadCard';

export default function Invited() {
  const [leads, setLeads] = useState([]);

  const fetchLeads = async () => {
    const res = await api.get('/leads/invited');
    setLeads(res.data);
  };

  const acceptLead = async (id) => {
    await api.post(`/leads/${id}/accept`);
    fetchLeads();
  };

  const declineLead = async (id) => {
    await api.post(`/leads/${id}/decline`);
    fetchLeads();
  };

  useEffect(() => {
    fetchLeads();
  }, []);

  return (
    <div>
      <h1 className="text-2xl font-bold mb-4">Invited Leads</h1>
      {leads.map(lead => (
        <LeadCard key={lead.id} lead={lead} onAccept={acceptLead} onDecline={declineLead} />
      ))}
    </div>
  );
}
