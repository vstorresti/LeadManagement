import React, { useEffect, useState } from 'react';
import api from '../services/api';
import LeadCard from '../components/LeadCard';

export default function Accepted() {
  const [leads, setLeads] = useState([]);

  const fetchLeads = async () => {
    const res = await api.get('/leads/accepted');
    setLeads(res.data);
  };

  useEffect(() => {
    fetchLeads();
  }, []);

  return (
    <div>
      <h1 className="text-2xl font-bold mb-4">Accepted Leads</h1>
      {leads.map(lead => (
        <LeadCard key={lead.id} lead={lead} />
      ))}
    </div>
  );
}
